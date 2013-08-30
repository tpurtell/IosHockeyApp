using System;

using MonoTouch.Foundation;

namespace IosHockeyApp {

	[BaseType (typeof (NSObject))]
	public partial interface BITHockeyManager {

		[Static, Export ("sharedHockeyManager"), Verify ("ObjC method massaged into getter property", "/Users/tj/Developer/iOSHockeyApp/SDK/HockeySDK.embeddedframework/HockeySDK.framework/Versions/A/Headers/BITHockeyManager.h", Line = 98)]
		BITHockeyManager SharedHockeyManager { get; }

		[Export ("configureWithIdentifier:delegate:")]
		void ConfigureWithIdentifier (string appIdentifier, NSObject delegate);

		[Export ("configureWithBetaIdentifier:liveIdentifier:delegate:")]
		void ConfigureWithBetaIdentifier (string betaIdentifier, string liveIdentifier, NSObject delegate);

		[Export ("startManager")]
		void StartManager ();

		[Export ("serverURL", ArgumentSemantic.Retain)]
		string ServerURL { get; set; }

		[Export ("crashManager", ArgumentSemantic.Retain)]
		BITCrashManager CrashManager { get; }

		[Export ("disableCrashManager")]
		bool DisableCrashManager { [Bind ("isCrashManagerDisabled")] get; set; }

		[Export ("updateManager", ArgumentSemantic.Retain)]
		BITUpdateManager UpdateManager { get; }

		[Export ("disableUpdateManager")]
		bool DisableUpdateManager { [Bind ("isUpdateManagerDisabled")] get; set; }

		[Export ("feedbackManager", ArgumentSemantic.Retain)]
		BITFeedbackManager FeedbackManager { get; }

		[Export ("disableFeedbackManager")]
		bool DisableFeedbackManager { [Bind ("isFeedbackManagerDisabled")] get; set; }

		[Export ("appStoreEnvironment")]
		bool AppStoreEnvironment { [Bind ("isAppStoreEnvironment")] get; }

		[Export ("debugLogEnabled")]
		bool DebugLogEnabled { [Bind ("isDebugLogEnabled")] get; set; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface BITHockeyManagerDelegate {

		[Export ("shouldUseLiveIdentifierForHockeyManager:")]
		bool  (BITHockeyManager hockeyManager);

		[Export ("viewControllerForHockeyManager:componentManager:")]
		UIViewController ComponentManager (BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export ("userIDForHockeyManager:componentManager:")]
		string ComponentManager (BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export ("userNameForHockeyManager:componentManager:")]
		string ComponentManager (BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export ("userEmailForHockeyManager:componentManager:")]
		string ComponentManager (BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);
	}

	[BaseType (typeof (NSObject))]
	public partial interface BITHockeyBaseManager {

		[Export ("serverURL", ArgumentSemantic.Copy)]
		string ServerURL { get; set; }

		[Export ("barStyle")]
		UIBarStyle BarStyle { get; set; }

		[Export ("tintColor", ArgumentSemantic.Retain)]
		UIColor TintColor { get; set; }

		[Export ("modalPresentationStyle")]
		UIModalPresentationStyle ModalPresentationStyle { get; set; }
	}

	public enum BITCrashManagerStatus : [unmapped: unexposed: Elaborated] {
		Disabled = 0,
		AlwaysAsk = 1,
		AutoSend = 2
	}

	[BaseType (typeof (BITHockeyBaseManager))]
	public partial interface BITCrashManager {

		[Export ("delegate", ArgumentSemantic.Assign)]
		NSObject Delegate { get; set; }

		[Export ("crashManagerStatus")]
		BITCrashManagerStatus CrashManagerStatus { get; set; }

		[Export ("showAlwaysButton")]
		bool ShowAlwaysButton { [Bind ("shouldShowAlwaysButton")] get; set; }

		[Export ("didCrashInLastSession")]
		bool DidCrashInLastSession { get; }

		[Export ("timeintervalCrashInLastSessionOccured")]
		double TimeintervalCrashInLastSessionOccured { get; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface BITCrashManagerDelegate {

		[Export ("applicationLogForCrashManager:")]
		string  (BITCrashManager crashManager);

		[Export ("userNameForCrashManager:")]
		string  (BITCrashManager crashManager);

		[Export ("userEmailForCrashManager:")]
		string  (BITCrashManager crashManager);

		[Export ("crashManagerWillShowSubmitCrashReportAlert:")]
		void  (BITCrashManager crashManager);

		[Export ("crashManagerWillCancelSendingCrashReport:")]
		void  (BITCrashManager crashManager);

		[Export ("crashManagerWillSendCrashReportsAlways:")]
		void  (BITCrashManager crashManager);

		[Export ("crashManagerWillSendCrashReport:")]
		void  (BITCrashManager crashManager);

		[Export ("crashManager:didFailWithError:")]
		void DidFailWithError (BITCrashManager crashManager, NSError error);

		[Export ("crashManagerDidFinishSendingCrashReport:")]
		void  (BITCrashManager crashManager);
	}

	public enum BITUpdateAuthorizationState : [unmapped: unexposed: Elaborated] {
		Denied,
		Allowed,
		Pending
	}

	public enum BITUpdateSetting : [unmapped: unexposed: Elaborated] {
		CheckStartup = 0,
		CheckDaily = 1,
		CheckManually = 2
	}

	[BaseType (typeof (BITHockeyBaseManager))]
	public partial interface BITUpdateManager : UIAlertViewDelegate {

		[Export ("delegate", ArgumentSemantic.Assign)]
		NSObject Delegate { get; set; }

		[Export ("updateSetting")]
		BITUpdateSetting UpdateSetting { get; set; }

		[Export ("checkForUpdateOnLaunch")]
		bool CheckForUpdateOnLaunch { [Bind ("isCheckForUpdateOnLaunch")] get; set; }

		[Export ("checkForUpdate")]
		void CheckForUpdate ();

		[Export ("alwaysShowUpdateReminder")]
		bool AlwaysShowUpdateReminder { get; set; }

		[Export ("showDirectInstallOption")]
		bool ShowDirectInstallOption { [Bind ("isShowingDirectInstallOption")] get; set; }

		[Export ("requireAuthorization")]
		bool RequireAuthorization { [Bind ("isRequireAuthorization")] get; set; }

		[Export ("authenticationSecret", ArgumentSemantic.Retain)]
		string AuthenticationSecret { get; set; }

		[Export ("expiryDate", ArgumentSemantic.Retain)]
		NSDate ExpiryDate { get; set; }

		[Export ("showUpdateView")]
		void ShowUpdateView ();

		[Export ("hockeyViewController:")]
		BITUpdateViewController HockeyViewController (bool modal);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface BITUpdateManagerDelegate {

		[Export ("customDeviceIdentifierForUpdateManager:")]
		string  (BITUpdateManager updateManager);

		[Export ("shouldDisplayExpiryAlertForUpdateManager:")]
		bool  (BITUpdateManager updateManager);

		[Export ("didDisplayExpiryAlertForUpdateManager:")]
		void  (BITUpdateManager updateManager);

		[Export ("updateManagerShouldSendUsageData:")]
		bool  (BITUpdateManager updateManager);

		[Export ("viewControllerForUpdateManager:")]
		UIViewController  (BITUpdateManager updateManager);
	}

	[BaseType (typeof (UITableViewController))]
	public partial interface BITHockeyBaseViewController {

		[Export ("modalAnimated")]
		bool ModalAnimated { get; set; }

		[Export ("initWithModalStyle:")]
		IntPtr Constructor (bool modal);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface BITFeedbackComposeViewControllerDelegate {

		[Export ("feedbackComposeViewControllerDidFinish:")]
		void  (BITFeedbackComposeViewController composeViewController);
	}

	[BaseType (typeof (UIViewController))]
	public partial interface BITFeedbackComposeViewController : UITextViewDelegate {

		[Export ("delegate", ArgumentSemantic.Assign)]
		BITFeedbackComposeViewControllerDelegate Delegate { get; set; }

		[Export ("prepareWithItems:")]
		void PrepareWithItems ([Verify ("NSArray may be reliably typed, check the documentation", "/Users/tj/Developer/iOSHockeyApp/SDK/HockeySDK.embeddedframework/HockeySDK.framework/Versions/A/Headers/BITFeedbackComposeViewController.h", Line = 72)] NSObject [] items);
	}

	public enum BITFeedbackUserDataElement : [unmapped: unexposed: Elaborated] {
		DontShow = 0,
		Optional = 1,
		Required = 2
	}

	[BaseType (typeof (BITHockeyBaseManager))]
	public partial interface BITFeedbackManager : UIAlertViewDelegate {

		[Export ("requireUserName")]
		BITFeedbackUserDataElement RequireUserName { get; set; }

		[Export ("requireUserEmail")]
		BITFeedbackUserDataElement RequireUserEmail { get; set; }

		[Export ("showAlertOnIncomingMessages")]
		bool ShowAlertOnIncomingMessages { get; set; }

		[Export ("showFeedbackListView")]
		void ShowFeedbackListView ();

		[Export ("feedbackListViewController:")]
		BITFeedbackListViewController FeedbackListViewController (bool modal);

		[Export ("showFeedbackComposeView")]
		void ShowFeedbackComposeView ();

		[Export ("feedbackComposeViewController"), Verify ("ObjC method massaged into getter property", "/Users/tj/Developer/iOSHockeyApp/SDK/HockeySDK.embeddedframework/HockeySDK.framework/Versions/A/Headers/BITFeedbackManager.h", Line = 209)]
		BITFeedbackComposeViewController FeedbackComposeViewController { get; }
	}

	[BaseType (typeof (UIActivity))]
	public partial interface BITFeedbackActivity : BITFeedbackComposeViewControllerDelegate {

		[Export ("customActivityImage", ArgumentSemantic.Retain)]
		UIImage CustomActivityImage { get; set; }

		[Export ("customActivityTitle", ArgumentSemantic.Retain)]
		string CustomActivityTitle { get; set; }
	}

	public enum BITCrashErrorReason : [unmapped: unexposed: Elaborated] {
		Unknown,
		APIAppVersionRejected,
		APIReceivedEmptyResponse,
		APIErrorWithStatusCode
	}

	public enum BITUpdateErrorReason : [unmapped: unexposed: Elaborated] {
		Unknown,
		APIServerReturnedInvalidStatus,
		APIServerReturnedInvalidData,
		APIServerReturnedEmptyResponse,
		APIClientAuthorizationMissingSecret,
		APIClientCannotCreateConnection
	}

	public enum BITFeedbackErrorReason : [unmapped: unexposed: Elaborated] {
		Unknown,
		APIServerReturnedInvalidStatus,
		APIServerReturnedInvalidData,
		APIServerReturnedEmptyResponse,
		APIClientAuthorizationMissingSecret,
		APIClientCannotCreateConnection
	}

	public enum BITHockeyErrorReason : [unmapped: unexposed: Elaborated] {
		Unknown,
		HockeyAPIClientMissingJSONLibrary
	}
}

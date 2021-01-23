	//AppDelegate.cs
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		public static UIStoryboard Storyboard = UIStoryboard.FromName ("MainStoryboard", null);
		public static UIViewController initialViewController;
		// ...
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			initialViewController = Storyboard.InstantiateInitialViewController () as UIViewController;
			UINavigationBar.Appearance.SetTitleTextAttributes (
				new UITextAttributes () { TextColor = UIColor.FromRGB (0, 127, 14) });
			window.RootViewController = initialViewController;
			window.MakeKeyAndVisible ();
			return true;
		}
	}

    UINavigationController navController;
		UIWindow window;
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			navController = new UINavigationController (new TestViewCtonroller ());
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			return true;
		}

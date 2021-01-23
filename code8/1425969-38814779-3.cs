    public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			this.Window = new UIWindow(UIScreen.MainScreen.Bounds);
			this.Window.RootViewController = new MyPageViewController();
			this.Window.MakeKeyAndVisible ();
			return true;
		}

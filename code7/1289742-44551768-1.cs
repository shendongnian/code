    public static UIViewController GetTopViewController()
	{
		var window = UIApplication.SharedApplication.KeyWindow;
		var vc = window.RootViewController;
		while (vc.PresentedViewController != null)
			vc = vc.PresentedViewController;
		if (vc is UINavigationController navController)
			vc = navController.ViewControllers.Last();
		return vc;
	}

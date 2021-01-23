    var window = UIApplication.SharedApplication.KeyWindow;
    var vc = window.RootViewController;
    while (vc.PresentedViewController != null)
        vc = vc.PresentedViewController;
    
    var navController = vc as UINavigationController;
    if (navController != null)
        vc = navController.ViewControllers.Last();

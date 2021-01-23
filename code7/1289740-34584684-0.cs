    var window= UIApplication.SharedApplication.KeyWindow;
    var vc = window.RootViewController;
    while (vc.PresentedViewController != null)
    {
        vc = vc.PresentedViewController;
    }

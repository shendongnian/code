    void ShowAlert(string message, double seconds)
    {
        var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
        var alertDelay = NSTimer.CreateScheduledTimer(seconds, obj =>
        {
            DismissMessage(alert, obj);
        });
        var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
        while (viewController.PresentedViewController != null)
        {
            viewController = viewController.PresentedViewController;
        }
        viewController.PresentViewController(alert, true, null);
    }

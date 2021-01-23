        void ShowAlert(string message, double seconds)
        {
            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.ActionSheet);
            var alertDelay = NSTimer.CreateScheduledTimer(seconds, obj =>
            {
                DismissMessage(alert, obj);
            });
            var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (viewController.PresentedViewController != null)
            {
                viewController = viewController.PresentedViewController;
            }
            viewController.PresentViewController(alert, true, () =>
            {
                UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(_ => DismissMessage(alert, null));
                alert.View.Superview?.Subviews[0].AddGestureRecognizer(tapGesture);
            });
        }

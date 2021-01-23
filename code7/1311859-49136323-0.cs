    void ShowAlert(string message, double seconds)
        {
			if(alert == null && alertDelay == null) {
				alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
				{
					DismissMessage();
				});
				alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
				UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
			}
        }
        void DismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
				alert = null;
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
				alertDelay = null;
            }
        }

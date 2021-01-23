    var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
                rootPage.NotifyUser("Exiting full screen mode", NotifyType.StatusMessage);
                // The SizeChanged event will be raised when the exit from full screen mode is complete.
            }
            else
            {
                if (view.TryEnterFullScreenMode())
                {
                    rootPage.NotifyUser("Entering full screen mode", NotifyType.StatusMessage);
                    // The SizeChanged event will be raised when the entry to full screen mode is complete.
                }
                else
                {
                    rootPage.NotifyUser("Failed to enter full screen mode", NotifyType.ErrorMessage);
                }
            }

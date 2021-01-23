           public bool SignalExternalCommandLineArgs(IList<string> args)
            {
                var uri = new Uri(StartupHelpers.GetConfigurationValue("ActivationUri"));
                int queryString = 0;
                if (StartupHelpers.IsTriggeredFromWLink(uri, out queryString))
                {
                    ((YourMainWindow) (Current.MainWindow)).LoadPage(queryString.ToString());
                    
                }
    
                // Bring window to foreground
                if (this.MainWindow.WindowState == WindowState.Minimized)
                    {
                    this.MainWindow.WindowState = WindowState.Normal;
                    }
    
                this.MainWindow.Activate();
    
                return true;
                }

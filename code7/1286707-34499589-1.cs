    private void InitializeThemes()
        {
            switch (AnalyticsInfo.VersionInfo.DeviceFamily)
            {
                case "Windows.Mobile":
                    StatusBar statusBar = StatusBar.GetForCurrentView();
                    break;
                case "Windows.Desktop":
                    ApplicationView applicationView = ApplicationView.GetForCurrentView();
                    break;
            }
        }

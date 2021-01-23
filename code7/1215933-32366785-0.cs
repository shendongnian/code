    if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
                {
                    var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                    statusBar.BackgroundColor = Windows.UI.Colors.Transparent;
                    statusBar.ForegroundColor = Windows.UI.Colors.Red;
                }

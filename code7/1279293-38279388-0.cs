    if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
    {
    var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
    statusBar.BackgroundColor = Windows.UI.Colors.Green;
    statusBar.BackgroundOpacity = 1;
    statusBar.ForegroundColor = Colors.White;
    }

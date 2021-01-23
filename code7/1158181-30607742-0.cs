    Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
    Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s,a) =>
    {
        Debug.WriteLine("BackRequested");
        if (Frame.CanGoBack)
        {
            Frame.GoBack();
            a.Handled = true;
        }
    }

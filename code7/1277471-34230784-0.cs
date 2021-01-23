            rootFrame.Navigated += OnNavigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
...
    }
    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            ((Frame)sender).CanGoBack ?
            AppViewBackButtonVisibility.Visible :
            AppViewBackButtonVisibility.Collapsed;
    }
    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame.CanGoBack)
        {
            e.Handled = true;
            rootFrame.GoBack();
        }
    }

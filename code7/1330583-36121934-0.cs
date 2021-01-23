    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bool optedIn = false;
            if ((bool)e.Parameter)
            {
                optedIn = true;
            }
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack && optedIn)
            {
                // If we have pages in our in-app backstack and have opted in to showing back, do so
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if there are no pages in our in-app back stack
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

    private void OnNavigated(object sender, NavigationEventArgs e)
        {
            // Each time a navigation event occurs, update the Back button's visibility
            Frame rootFrame = (Frame)sender;
            if (rootFrame.BackStack != null && rootFrame.BackStack.Count == 1)
            {
                // take care in page names
                if (rootFrame.BackStack[0].SourcePageType.Name == "MainPage"
                    || rootFrame.BackStack[0].SourcePageType.Name == "AnyOtherPage")
                {
                    rootFrame.BackStack.RemoveAt(0);
                }
            }
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                ((Frame)sender).CanGoBack ?
                AppViewBackButtonVisibility.Visible :
                AppViewBackButtonVisibility.Collapsed;
        }

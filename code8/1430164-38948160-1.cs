    SystemNavigationManager.GetForCurrentView().BackRequested +=OnBackRequested;
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame?.CanGoBack==true)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
            else
            {
                Application.Current.Exit();
            }
        }
    }

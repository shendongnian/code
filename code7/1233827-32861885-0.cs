    private void RequestCallback()
    {
        Dispatcher.BeginInvoke(() => 
        {
            // Here, we are in the UI thread
            if (isActive)
            {
                // The page is still active, trigger the navigation
                NavigationService.Navigate(...);
            }
        });
    }

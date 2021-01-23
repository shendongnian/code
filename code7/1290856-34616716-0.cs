    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
                base.OnNavigatedFrom(e);
                SystemNavigationManager.GetForCurrentView().BackRequested -= SystemNavigationManager_BackRequested;
    }

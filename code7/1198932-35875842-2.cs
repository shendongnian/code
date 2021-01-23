    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        ...
        SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        Window.Current.Activate();
    }
        

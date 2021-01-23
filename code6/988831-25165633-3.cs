    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        SystemTray.ProgressIndicator = new ProgressIndicator();
    }

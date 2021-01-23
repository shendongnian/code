    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        App.Current.Resuming -= App_resuming;
        App.Current.Suspending -= App_suspending;
        _mediaCapture.Dispose();
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        App.Current.Resuming += App_resuming;
        App.Current.Suspending += App_suspending;
    }
    private void App_suspending(object sender, SuspendingEventArgs args)
    {
        _mediaCapture.Dispose();
    }
    private void App_resuming(object sender, object e)
    {
        //reinitialize _mediaCapture object
    }

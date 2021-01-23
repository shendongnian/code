    private AppSynchronization appSynchronization;
    public App()
    {
        ...
        this.appSynchronization = new AppSynchronization();
    }
    protected async override void OnLaunched(LaunchActivatedEventArgs e)
    {
        ... 
        if (rootFrame.Content == null)
        {
            // Advertise the fact that the main app wants to start. 
            // The background agent will know to cancel whatever its doing.
            // ActivateMainApp may have to be async although you need to make sure that OnLaunched supports that
            this.appSynchronization.ActivateMainApp();
            ...
        }
    }
    private async void OnResuming(object sender, object e)
    {
        ...
        // Advertise the fact that the main app wants to resume.
        // The background agent will know to cancel whatever its doing.
        this.appSynchronization.ActivateMainApp();
    }
    private async void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        ...
        // Advertise the fact that the main app is suspending.
        // The background agent will know it is allowed to start doing work.
        await _mainAppSynchronization.MainAppSuspended();
        ...
        deferral.Complete();
    }
    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        ...
        // Advertise the fact that the main app is going away.
        // The background agent will know it is allowed to start doing work.
        _mainAppSynchronization.MainAppSuspended().Wait();
    }

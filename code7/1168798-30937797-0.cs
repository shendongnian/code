    public void Start(ISplashScreen splashScreen, ...)
    {
        InitializationResult initializationResult = null;
        var progress = new Progress<int>((steps) => splashScreen.IncrementProgress(steps));
        splashScreen.Started += async (sender, args) => await Task.Factory.StartNew(
                 // Perform non-GUI initialization - The GUI thread will be responsive in the meantime.
                 () => Initialize(..., progress, out initializationResult)
            ).ContinueWith(
                // Perform GUI initialization afterwards in the UI context
                (task) =>
                    {
                        InitializeGUI(initializationResult, progress);
                        splashScreen.CloseSplash();
                    },
                TaskScheduler.FromCurrentSynchronizationContext()
            );
        splashScreen.Finished += (sender, args) => RunApplication(initializationResult);
        splashScreen.SetProgressRange(0, initializationSteps);        
        splashScreen.ShowSplash();
        Application.Run();
    }

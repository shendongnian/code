    private static readonly ManualResetEvent resetEvent = new ManualResetEvent(false);
        
    public App()
    {
    	
    	this.InitializeComponent();
    	this.Suspending += OnSuspending;
    
    	this.UnhandledException += OnUnhandledException;
    }
    
    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
    	// Run a separate thread to write to the logs and then Wait until the ManualResetEvent is set
    	// This stops the application exiting early and not logging to the logs.
    	Task.Run(async () =>
    	{
    		await DependencyService.Get<IFileWriter>().ErrorAsync(e.Exception);
    		resetEvent.Set();
    	});
    	
    	resetEvent.WaitOne();
    }

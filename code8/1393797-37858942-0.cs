    public App()
    {
       this.InitializeComponent();
       this.Suspending += this.OnSuspending;
       this.UnhandledException += UnhandledExceptionHandler;
    }
    private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
       log.Critical(e.Exception);
    }

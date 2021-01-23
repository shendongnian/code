    public App()
    {
        this.InitializeComponent();
        this.Suspending += OnSuspending;
        this.UnhandledException += App_UnhandledException;
    }
    
    private async void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        e.Handled = true;
        await HandleException(e.Exception);
    }
    
    public async Task HandleException(Exception exception)
    {
        var dialog = new MessageDialog(exception.Message, "Exception occurred");
        await dialog.ShowAsync();
    }

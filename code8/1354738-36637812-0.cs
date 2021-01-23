    public App()
    {
        this.InitializeComponent();
        this.Suspending += OnSuspending;
        this.UnhandledException += (sender, e) =>
        {
            e.Handled = true;
            System.Diagnostics.Debug.WriteLine(e.Exception);
        };
    }

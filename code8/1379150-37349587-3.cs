    public UnitTestApp()
    {
        CoreApplication.UnhandledErrorDetected += UnhandledError;
        // ...and any other initialization.
        // The InitializeComponent call just sets up error handlers,
        // and you can probably do without in the case of the App class.
        // This can be useful for debugging XAML:
        DebugSettings.IsBindingTracingEnabled = true;
        DebugSettings.BindingFailed +=
            (sender, args) => Debug.WriteLine(args.Message);
    }

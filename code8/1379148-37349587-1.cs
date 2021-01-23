    public UnitTestApp()
    {
        CoreApplication.UnhandledErrorDetected += UnhandledError;
        // ...and whatever else. The InitializeComponent call generally
        // doesn't do much more than what you showed in the OP, and
        // you can probably do without in the case of the App class.
        // This can be useful for debugging XAML:
        DebugSettings.IsBindingTracingEnabled = true;
        DebugSettings.BindingFailed +=
            (sender, args) => Debug.WriteLine(args.Message);
    }

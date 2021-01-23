    ...
    using Windows.ApplicationModel;
    ...
    
    public App()
    {
    	InitializeComponent();            
    	this.Suspending += OnSuspending;
    }
    ...
    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        //Add your logic here, if any
        deferral.Complete();
    }

    public MyUI()
    {
        // This call is required by the designer.
        InitializeComponent();
    
        // Add any initialization after the InitializeComponent() call.
        CheckResult(PopulateUI());
    }
    
    private async Task PopulateUI()
    {
        var data = await FetchUiData();
        SetControlValues(data); // or whatever
    }
    private static void CheckResult(Task t) {
        // We want to be doing this on the UI thread
        var sched = TaskScheduler.FromCurrentSynchronizationContext();
        t.ContinueWith(() => {
           // check if "t" faulted and perform appropriate action
        }, sched);
    }

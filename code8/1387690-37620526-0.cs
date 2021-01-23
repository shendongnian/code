    public StartPage ()
    {
        InitializeComponent ();
        
        Appearing += async (sender, args) => await loadCommand();
    }
    async Task loadCommand ()
    {
        var theTask = new StartPageViewModel ();
        await theTask.ExecuteCommand ();
    }

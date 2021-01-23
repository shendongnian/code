    public StartPage ()
    {
        InitializeComponent ();
        
        Appearing += async (sender, args) => await loadCommand();
    }
    async Task loadCommand ()
    {
        var viewModel = new StartPageViewModel();
        await viewModel.ExecuteCommand();
    }

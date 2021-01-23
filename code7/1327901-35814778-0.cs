    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        MainViewModel = (MainViewModel)ViewModel;
    }

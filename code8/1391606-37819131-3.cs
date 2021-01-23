    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        var viewModel = pivot.DataContext as ViewModel;
        await viewModel.LoadFeeds();
    }

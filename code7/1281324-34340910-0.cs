    protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
    {
        SystemNavigationManager.GetForCurrentView().BackRequested += this.OnBackPressed;
        base.OnNavigatedTo(e);
    }

    public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
    {
        var frame = NavigationService.Frame;
        NavigationService.Navigate(typeof(Views.MainPage));
        return Task.CompletedTask;
    }

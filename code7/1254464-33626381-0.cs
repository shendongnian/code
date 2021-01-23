    sealed partial class App : BootStrapper
    {
    public App()
    {
        this.InitializeComponent();
    }
    public override Task OnInitializeAsync(IActivatedEventArgs args)
    {
        var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
        Window.Current.Content = new Views.Shell(nav);
        return Task.FromResult<object>(null);
    }
    public override Task OnStartAsync(BootStrapper.StartKind startKind, IActivatedEventArgs args)
    {
        NavigationService.Navigate(typeof(Views.MainPage));
        return Task.FromResult<object>(null);
    }
    }

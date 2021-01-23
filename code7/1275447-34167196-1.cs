    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            this.InitializeComponent();
        }
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
            return Task.FromResult<object>(null);
        }
    }

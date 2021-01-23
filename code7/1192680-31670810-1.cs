    sealed partial class App : Common.BootStrapper
    {
        public App()
        {
            InitializeComponent();
            this.SplashFactory = (e) => null;
        }
        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // start the user experience
            NavigationService.Navigate(typeof(Views.MainPage), "123");
            return Task.FromResult<object>(null);
        }
        public override Task OnSuspendingAsync(object s, SuspendingEventArgs e)
        {
            // handle suspending
        }
        public override void OnResuming(object s, object e)
        {
            // handle resuming
        }
    }

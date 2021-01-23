    public sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            InitializeComponent();
        }
        protected override UIElement CreateShell(Frame rootFrame)
        {
            var masterPage = Container.Resolve<MasterPage>();
            masterPage.MyFrame = rootFrame;
            return masterPage;
        }
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(Keys.MainPage, null);
            return Task.FromResult(true);
        }
    }

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void WebView_LoadCompleted(object sender, NavigationEventArgs e)
        {
            ProgressRing.Visibility = Visibility.Collapsed;
        }
    }

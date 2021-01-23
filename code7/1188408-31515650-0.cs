    public partial class HomeView : PhoneApplicationPage
    {
        public HomeView()
        {
            InitializeComponent();
            Loaded += HomeView_Loaded;
        }
        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            UserAgentHelper.GetUserAgent(
                LayoutRoot,
                userAgent =>
                    {
                    // TODO: Store this wherever you want
                    ApplicationSettings.Current.UserAgent = userAgent;
                   });
        }
    }

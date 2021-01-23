    namespace Cache
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class Page1 : Page
        {
            public Page1()
            {
                this.InitializeComponent();
                this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            }
    
            private void NaviToMainPage(object sender, RoutedEventArgs e)
            {
                this.Frame.Navigate(typeof(MainPage));
                var rootFrame = Window.Current.Content as Frame;
                if (rootFrame != null)
                {
                    var cacheSize = ((rootFrame)).CacheSize;
                    ((rootFrame)).CacheSize = 0;
                    ((rootFrame)).CacheSize = cacheSize;
                }
            }
        }
    }

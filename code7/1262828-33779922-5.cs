    namespace Cache
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class Page2 : Page
        {
            public Page2()
            {
                this.InitializeComponent();
                this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            }
    
            private void NaviToPage1(object sender, RoutedEventArgs e)
            {
                var frame = this.Frame;
                if (frame != null)
                {
                    var cacheSize = ((frame)).CacheSize;
                    ((frame)).CacheSize = 0;
                    ((frame)).CacheSize = cacheSize;
                }
                this.Frame.Navigate(typeof(Page1));          
            }
        }
    }

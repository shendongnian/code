        public sealed partial class RootControl : UserControl
        {
            private Type currentPage;
        
            public RootControl()
            {
                this.InitializeComponent();
                RootFrame.Navigated += OnNavigated;
            }
            private void OnNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
            {
                currentPage = e.SourcePageType;
            }
            public Frame RootFrame
            {
                get
                {
                    return rootFrame;
                 }
            }
            private void OnHomeClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                Navigate(typeof(MainPage));
            }
            private void OnShopClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                 Navigate(typeof(StorePage));
            }
            private void OnSettingsClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                 Navigate(typeof(SettingsPage));
            }
            private void Navigate(Type pageSourceType)
            {
                if (currentPage != pageSourceType)
                {
                    RootFrame.Navigate(pageSourceType);
                }
            }
        }

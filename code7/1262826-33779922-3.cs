    namespace Cache
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
    
            private void Button_Click_Pane(object sender, RoutedEventArgs e)
            {
                this.RootSpiltView.IsPaneOpen = !this.RootSpiltView.IsPaneOpen; 
            }
    
            private void OnFrameNavigating(object sender, NavigatingCancelEventArgs e)
            {
                string msg = "Frame's Navigating event happening, SourcePageType = {0}";
                System.Diagnostics.Debug.WriteLine(msg, e.SourcePageType);
            }
    
            private void OnFrameNavigated(object sender, NavigationEventArgs e)
            {
                string msg = "Frame's Navigated event happening, SourcePageType = {0}";
                System.Diagnostics.Debug.WriteLine(msg, e.SourcePageType);
            }
    
            private void FrameToPage2(object sender, RoutedEventArgs e)
            {
                frame.Navigate(typeof(Page2));
            }
    
            private void MainPageToPage1(object sender, RoutedEventArgs e)
            {
                this.Frame.Navigate(typeof(Page1));
            }
        }
    }

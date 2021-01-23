     public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                Loaded += MainPage_Loaded;
            }
    
            private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                string src = "ms-appx-web:///Assets/MyHTMLPage.html";
                this.MyWebView.Navigate(new Uri(src));
            }
        }

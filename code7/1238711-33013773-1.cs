        public class Site
        {
            public Uri NavigateUri { get; set; }
        }
        public partial class MainWindow : Window
        {
    
            private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
            }
    
         public MainWindow()
            {
                InitializeComponent();
    
                
                List<Site> sites = new List<Site>();
                sites.Add(new Site() { NavigateUri = new Uri("http://www.google.com", UriKind.RelativeOrAbsolute) });
                sites.Add(new Site() { NavigateUri = new Uri("http://www.yahoo.com", UriKind.RelativeOrAbsolute) });
                sites.Add(new Site() { NavigateUri = new Uri("http://www.microsoft.com", UriKind.RelativeOrAbsolute) });
                this.tvList.ItemsSource = sites;
    
            }
        }

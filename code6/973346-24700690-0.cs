    public partial class MainPage : UserControl
        {
            public MainPage()
            {
                InitializeComponent();
                Loaded += MainPage_Loaded;
           
            }
    
           private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                Visibility = Visibility.Collapsed;
                loginChildWindow log = new loginChildWindow(this);
                log.Show();
                           
            }
           public void loginWnd_Closed(object sender, EventArgs e)
           {
               this.Visibility = Visibility.Visible;
           }
    
        } 

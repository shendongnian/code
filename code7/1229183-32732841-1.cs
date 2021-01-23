    public partial class MainWindow : Window
    {
       public MainWindow()
       {
            this.InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LeftNavigationFrame.NavigationService.Navigate(new Uri(...));
        }
    }

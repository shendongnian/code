    public partial class MainWindow : Window
        {
            ViewModel _viewModel;
    
            public MainWindow()
            {
                _viewModel = new ViewModel();
                this.DataContext = _viewModel;
               
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();
    
            }
        }

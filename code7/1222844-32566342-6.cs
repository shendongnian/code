    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)DataContext; }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
            var tableViewWindow = new TableView(ViewModel.NumberOfRows, ViewModel.NumberOfColumns);
            this.Close();
            tableViewWindow.Show();
        }
    }

    public partial class MainWindow : Window
    {
        private Logger _logger;
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new ViewModel();
            DataContext = viewModel;
            _logger = new Logger(viewModel); // passing ViewModel through Dependency Injection
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _logger.Write("ewgewgweg");
        }
    }

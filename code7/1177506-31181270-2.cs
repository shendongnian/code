     public partial class MainWindow : Window {
        private ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.LuminRecevied += "h";
        }
    }

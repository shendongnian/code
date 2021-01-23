    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void UserControl1_Click(object sender, RoutedEventArgs e)
        {
            App.ReportClick((FrameworkElement)e.Source);
        }
    }

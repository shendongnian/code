<!-- -->
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            flyout.IsOpen = true;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            flyout.IsOpen = false;
        }
    }

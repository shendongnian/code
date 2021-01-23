        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            
        }
        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                RadioButton rb = menuItem.Icon as RadioButton;
                if (rb != null)
                {
                    rb.IsChecked = true;
                }
            }
        }
    }

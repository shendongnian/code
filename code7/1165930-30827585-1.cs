    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnGetParent_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = TryFindParent<TabItem>(sender as Button);
            MessageBox.Show(ti.Header.ToString());
        }
    }

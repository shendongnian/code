     public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new UserControl1();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cntCtrl.Content = new UserControl2();
        }
    }

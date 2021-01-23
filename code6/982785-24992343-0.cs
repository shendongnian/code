    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestWindow.MouseDown += TestResize;
        }
        private void TestResize(object sender, MouseButtonEventArgs e)
        {
            var mdiChild = sender as MdiChild;
            if (mdiChild != null)
            {
                mdiChild.WindowState = WindowState.Maximized;
            }
        }
    }

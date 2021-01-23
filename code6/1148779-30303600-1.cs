    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TargetCanvas.LayoutUpdated += TargetCanvas_LayoutUpdated;
        }
        void TargetCanvas_LayoutUpdated(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + ": Layout updated\n");
        }
    }

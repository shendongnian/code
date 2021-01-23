    public partial class MainWindow : Window
    {
        private static int _nextId = 0;
        public static int NextId
        {
            get { return _nextId++; }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // add non-multiple of 8 to see how layout works
            for (var i=0; i<7; i++)
            {
                MainPanel.Children.Add(new EditPanelControl());
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty SelectedServerProperty =
             DependencyProperty.Register("SelectedServer", typeof(int),
             typeof(MainWindow), new FrameworkPropertyMetadata(0, SelectedIndexPropertyChangedCallback));
        public static readonly DependencyProperty SelectedBuildProperty =
             DependencyProperty.Register("SelectedBuild", typeof(int),
             typeof(MainWindow), new FrameworkPropertyMetadata(0));
        public static readonly DependencyProperty BuildsListProperty =
             DependencyProperty.Register("BuildsList", typeof(object),
             typeof(MainWindow), new FrameworkPropertyMetadata(null));
        public int SelectedServer
        {
            get { return (int)GetValue(SelectedServerProperty); }
            set { SetValue(SelectedServerProperty, value); }
        }
        public int SelectedBuild
        {
            get { return (int)GetValue(SelectedBuildProperty); }
            set { SetValue(SelectedBuildProperty, value); }
        }
        public object BuildsList
        {
            get { return GetValue(BuildsListProperty); }
            set { SetValue(BuildsListProperty, value); }
        }
        static void SelectedIndexPropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = sender as MainWindow;
            window.GenerateBuilds();
        }
        void GenerateBuilds()
        {
            var selectedServer = SelectedServer + 1;
            BuildsList = new List<string>() {
                "Build 1." + selectedServer, "Build 2." + selectedServer, "Build 3." + selectedServer };
            SelectedBuild = 0;
        }
        public MainWindow()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
            GenerateBuilds();
        }
    }

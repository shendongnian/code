    public partial class MainWindow : Window
    {
        static frmFilters filterWindowInstance = new frmFilters(OpenDataDisplay);
        static frmDataDisplay dataWindowInstance = new frmDataDisplay(OpenFilters);
        static void OpenFilters()
        {
            filterWindowInstance.Visibility = Visibility.Visible;
            dataWindowInstance.Visibility = Visibility.Collapsed;
        }
        static void OpenDataDisplay()
        {
            filterWindowInstance.Visibility = Visibility.Collapsed;
            dataWindowInstance.Visibility = Visibility.Visible;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFilters();
            Visibility = Visibility.Collapsed;
        }
    }
    public partial class frmFilters : Window
    {
        Action CloseFilterOpenData;
        public frmFilters(Action CloseFilterOpenDataToSet)
        {
            InitializeComponent();
            CloseFilterOpenData = CloseFilterOpenDataToSet;
        }
        private void cmdHideThis_Click(object sender, RoutedEventArgs e)
        {
            CloseFilterOpenData();
        }
    }
    public partial class frmDataDisplay : Window
    {
        Action CloseDataOpenFilter;
        public frmDataDisplay(Action CloseDataOpenFilterToSet)
        {
            InitializeComponent();
            CloseDataOpenFilter = CloseDataOpenFilterToSet;
        }
        private void cmdHideThis_Click(object sender, RoutedEventArgs e)
        {
            CloseDataOpenFilter();
        }
    }

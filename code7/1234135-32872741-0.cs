    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public IEnumerable<string> Routes
        {
            get
            {
                return new string[] { "a", "b", "c", "d" };
            }
        }
        public string DefaultRoute
        {
            get
            {
                return _defaultRoute;
            }
            set
            {
                _defaultRoute = value;
                // Handle saving/storing setting here, when selection has changed
                //MySettings.Default.DefaultRoute = value;
                NotifyPropertyChanged();
            } 
        }
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            DefaultRoute = MySettings.Default.DefaultRoute;
        }
        private string _defaultRoute;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void RouteFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
    public static class MySettings
    {
        public static class Default
        {
            public static string DefaultRoute = "a";
        }
    }

        public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private GraphicsList _graphicsData;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            this.Loaded += MainWindow_Loaded;
        }
        public GraphicsList GraphicsData
        {
            get { return _graphicsData; }
            set
            {
                if (Equals(value, _graphicsData)) return;
                _graphicsData = value;
                OnPropertyChanged("GraphicsData");
            }
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //var resource = this.Resources["GraphicsData"] as GraphicsList;
            
            var resource = new GraphicsList();
            resource.Add(new Graphics(){Name = "Some new Collection of data"});
            this.GraphicsData = resource;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

        public BitmapImage theImage {get; set;}
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            theImage = new BitmapImage();
            theImage.BeginInit();
            theImage.UriSource = new Uri("dice.png", UriKind.Relative);
            theImage.CacheOption = BitmapCacheOption.OnLoad;
            theImage.EndInit();
            OnPropertyChanged("theImage");
        }

    public MainWindow()
        {
            InitializeComponent();
            theImage.BeginInit();
            theImage.UriSource = new Uri("dice.png", UriKind.Relative);
            theImage.CacheOption = BitmapCacheOption.OnLoad;
            theImage.EndInit();
            MyImage.Source = theImage;
        }

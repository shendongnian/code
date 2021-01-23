     public static AppBar _globalAppBar = new AppBar();
        public MainPage()
        {
            this.InitializeComponent();
            SetUpBar();
        }
        public void SetUpBar()
        {
            _globalAppBar = new AppBar();
            //SIZE
            _globalAppBar.Height = 250;
            _globalAppBar.Name = "appBar";
            //BACKGROUND
            _globalAppBar.Background = new SolidColorBrush(Colors.PaleVioletRed);
            BitmapImage bmI = new BitmapImage();
            bmI= new BitmapImage(new Uri("ms-appx:///Assets/1.jpg", UriKind.RelativeOrAbsolute));
            var imageBrush = new ImageBrush();
            imageBrush.ImageSource = bmI;
            _globalAppBar.Background = imageBrush;
            AppBarButton abbtn = new AppBarButton();
            abbtn.Label = "Hello";
            _globalAppBar.Content = abbtn;
            this.TopAppBar = _globalAppBar;
           
        }
        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider sl = (Slider)sender;
            if (sl.Value!=0)
            {
                _globalAppBar.Height = sl.Value;
            }
        }

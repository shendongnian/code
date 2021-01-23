     public partial class Preview : Window
    {
        DispatcherTimer ThreeSec = new DispatcherTimer();
        public Preview()
        {
            InitializeComponent();
        }
        public Preview(string imgSource)
        {
            InitializeComponent();
            imgPreview.Source = new BitmapImage(new Uri(imgSource));
            imgPreview.Stretch = Stretch.UniformToFill;
            ThreeSec.Interval = TimeSpan.FromSeconds(3);
            ThreeSec.Tick += ThreeSec_Tick;
            Loaded += Preview_Loaded;
            
        }
        private void ThreeSec_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Preview_Loaded(object sender, RoutedEventArgs e)
        {
            ThreeSec.Start();
        }
    }

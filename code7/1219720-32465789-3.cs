     public partial class Preview : Window
    {
        public Preview()
        {
            InitializeComponent();
        }
        public Preview(string imgSource)
        {
            InitializeComponent();
            imgPreview.Source = new BitmapImage(new Uri(imgSource));
            imgPreview.Stretch = Stretch.UniformToFill;
        }
    }

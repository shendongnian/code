    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var brush = new ImageBrush(new BitmapImage(new Uri("thumbnail.jpg", UriKind.Relative)));
            canvas_view.Background = brush;
            this.Loaded += MainWindow_Loaded;
        }
        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var bi = await LoadBigImage();
            canvas.Background = new ImageBrush(bi);
        }
        async Task<BitmapImage> LoadBigImage()
        {
            var bi = new BitmapImage(new Uri("fullsize.jpg", UriKind.Relative));
            bi.Freeze(); // note: must freeze DP objects when passing between threads
            return bi;
        }
    }

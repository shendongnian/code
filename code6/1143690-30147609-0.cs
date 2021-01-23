    public partial class MainWindow : Window
    {
        private float _angle = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonTestImage_OnClick(object sender, RoutedEventArgs e)
        {
            var backgroundImage = new Bitmap(@"Assets\dial.png");//Compass circle
            System.Drawing.Size finalSize = backgroundImage.Size;
            var foregroundImage = new Bitmap(@"Assets\arrow.png");//Compass needle
            foregroundImage = new Bitmap(foregroundImage, 13, 65);
            var finalImage = new Bitmap(finalSize.Width, finalSize.Height);
            using (var graphics = Graphics.FromImage(finalImage))
            {
                graphics.DrawImage(backgroundImage, 0, 0, backgroundImage.Width, backgroundImage.Height);
                graphics.TranslateTransform(backgroundImage.Width / 2f, backgroundImage.Height / 2f);
                graphics.RotateTransform(_angle);
                graphics.TranslateTransform(foregroundImage.Width / -2f, foregroundImage.Height / -2f);
                graphics.DrawImage(foregroundImage, Point.Empty);
            }
            var image = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(finalImage.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromWidthAndHeight(finalSize.Width, finalSize.Height));
            ImageTest.Source = image;
            _angle += 20;
            if (_angle >= 360)
            {
                _angle = 0;
            }
        }
    }

    public sealed partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush imgB = new ImageBrush();
            BitmapImage btpImg = new BitmapImage();
            btpImg.UriSource = new Uri(@"ms-appx:///images/bg-light-blue.png");
            imgB.ImageSource = btpImg;
            container.Background = imgB;
        }
    }

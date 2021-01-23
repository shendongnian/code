    public sealed partial class CustomImage : UserControl
    {
        public static readonly DependencyProperty ImageSourceStringProperty = DependencyProperty.Register("ImageSourceString", typeof(string), typeof(CustomImage), new PropertyMetadata(null, new PropertyChangedCallback(ImageSourceStringChanged)));
        public string ImageSourceString
        {
            get { return (string)GetValue(ImageSourceStringProperty); }
            set
            {
                SetValue(ImageSourceStringProperty, value);
            }
        }
        private static void ImageSourceStringChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            CustomImage currentImage = obj as CustomImage;
            string path = e.NewValue as string;
            MainPage.logMsg("ImageSource = " + path);
            if (string.IsNullOrEmpty(path))
            {
                Uri imageFileUri = new Uri("ms-appx:///Assets/Images/failed.png");
                currentImage.mainImage.ImageSource = new BitmapImage(imageFileUri);
            }
            else
            {
                Uri imageFileUri = null;
                try
                {
                    imageFileUri = new Uri(path);
                }
                catch
                {
                    imageFileUri = new Uri("ms-appx:///Assets/Images/failed.png");
                }
                if (imageFileUri != null)
                {
                    currentImage.mainImage.ImageSource = new BitmapImage(imageFileUri);
                }
            }
        }
        public CustomImage()
        {
            this.InitializeComponent();
        }
    }

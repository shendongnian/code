    public partial class ImageFolder : UserControl
    {
        public static DependencyProperty SecondImageProperty = DependencyProperty.Register("SecondImage", typeof(ImageSource), typeof(ImageFolder), new FrameworkPropertyMetadata(new PropertyChangedCallback(SecondImage_Changed)));
        public static DependencyProperty FirstImageProperty = DependencyProperty.Register("FirstImage", typeof(ImageSource), typeof(ImageFolder), new FrameworkPropertyMetadata(new PropertyChangedCallback(FirstImage_Changed)));
        public ImageSource FirstImage
        {
            get { return (ImageSource)GetValue(FirstImageProperty); }
            set { SetValue(FirstImageProperty, value); }
        }
        private static void FirstImage_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ImageFolder thisClass = (ImageFolder)o;
            thisClass.SetFirstImage();
        }
        private void SetFirstImage()
        {
            //Put Instance FirstImage Property Changed code here
        }
        public ImageSource SecondImage
        {
            get { return (ImageSource)GetValue(SecondImageProperty); }
            set { SetValue(SecondImageProperty, value); }
        }
        private static void SecondImage_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            ImageFolder thisClass = (ImageFolder)o;
            thisClass.SetSecondImage();
        }
        private void SetSecondImage()
        {
            //Put Instance SecondImage Property Changed code here
        }
        public ImageFolder()
        {
            InitializeComponent();
        }
    }

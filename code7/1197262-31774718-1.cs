    public static class AttachedProperties
    {
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.RegisterAttached("ImageSource", typeof(ImageSource), typeof(AttachedProperties), new UIPropertyMetadata(null));
        public static void SetImageSource(DependencyObject d, ImageSource source)
        {
            d.SetValue(ImageSourceProperty, source);
        }
        public static ImageSource GetImageSource(DependencyObject d)
        {
            return (ImageSource)d.GetValue(ImageSourceProperty);
        }
    }

    class CustomElement : FrameworkElement
    {
        public ImageSource Image1
        {
            get { return (ImageSource)GetValue(Image1Property); }
            set { SetValue(Image1Property, value); }
        }
        public static readonly DependencyProperty Image1Property = DependencyProperty.Register("Image1", typeof(ImageSource), typeof(CustomElement),
            new FrameworkPropertyMetadata((ImageSource)null, FrameworkPropertyMetadataOptions.AffectsRender));
        public ImageSource Image2
        {
            get { return (ImageSource)GetValue(Image2Property); }
            set { SetValue(Image2Property, value); }
        }
        public static readonly DependencyProperty Image2Property = DependencyProperty.Register("Image2", typeof(ImageSource), typeof(CustomElement),
            new FrameworkPropertyMetadata((ImageSource)null, FrameworkPropertyMetadataOptions.AffectsRender));
        public ImageSource Image3
        {
            get { return (ImageSource)GetValue(Image3Property); }
            set { SetValue(Image3Property, value); }
        }
        public static readonly DependencyProperty Image3Property = DependencyProperty.Register("Image3", typeof(ImageSource), typeof(CustomElement),
            new FrameworkPropertyMetadata((ImageSource)null, FrameworkPropertyMetadataOptions.AffectsRender));
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawImage(Image1, new Rect(0.0, 0.0, ActualWidth, ActualHeight * 0.5));
            drawingContext.DrawImage(Image2, new Rect(0.0, ActualHeight * 0.5, ActualWidth * 0.75, ActualHeight * 0.5));
            drawingContext.DrawImage(Image3, new Rect(ActualWidth * 0.75, ActualHeight * 0.5, ActualWidth * 0.25, ActualHeight * 0.5));
        }
    }

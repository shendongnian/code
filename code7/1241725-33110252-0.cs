     public MySlider1()
        {
            InitializeComponent();
            Resources["BRadiusX"] = BorderRadiusX;
            Resources["BRadiusY"] = BorderRadiusY;
        }
       protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Resources["BRadiusX"] = BorderRadiusX;
            Resources["BRadiusY"] = BorderRadiusY;
        }
        public static DependencyProperty BorderRadiusXProperty = DependencyProperty.Register("BorderRadiusX", typeof(double), typeof(MySlider1),
        new FrameworkPropertyMetadata(5.0, FrameworkPropertyMetadataOptions.AffectsRender));
        [Category("Thumb"), Description("XRadius of border round the thumb")]
        public double BorderRadiusX
        {
            get { return (double)GetValue(BorderRadiusXProperty); }
            set { SetValue(BorderRadiusXProperty, value); }
        }
        public static DependencyProperty BorderRadiusYProperty = DependencyProperty.Register("BorderRadiusY", typeof(double), typeof(MySlider1),
        new FrameworkPropertyMetadata(5.0, FrameworkPropertyMetadataOptions.AffectsRender));
        [Category("Thumb"), Description("YRadius of border round the thumb")]
        public double BorderRadiusY
        {
            get { return (double)GetValue(BorderRadiusYProperty); }
            set { SetValue(BorderRadiusYProperty, value); }
        }

    public partial class Camera : UserControl
    {
        public Camera()
        {
            InitializeComponent();
        }
        #region HorizontalOffset
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        public static readonly DependencyProperty HorizontalOffsetProperty =
            DependencyProperty.RegisterAttached("HorizontalOffset", typeof(object), typeof(Camera),new UIPropertyMetadata(null, HorizontalOffsetPropertyChanged));
        public static object GetHorizontalOffset(DependencyObject obj)
        {
            return (string)obj.GetValue(HorizontalOffsetProperty);
        }
        public static void SetHorizontalOffset(DependencyObject obj, object value)
        {
            obj.SetValue(HorizontalOffsetProperty, value);
        }
        public static void HorizontalOffsetPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Camera cam = o as Camera;
            ScrollViewer scroll=cam.Template.FindName("cameraViewer", cam) as ScrollViewer;
            double horizontal = 0;
            if (e.NewValue is double)
            {
                horizontal =(double) e.NewValue;
            }
            scroll.ScrollToHorizontalOffset(horizontal);
        }
        #endregion
        #region VerticalOffset
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.RegisterAttached("VerticalOffset", typeof(object), typeof(Camera), new UIPropertyMetadata(null, VerticalOffsetPropertyChanged));
        public static object GetVerticalOffset(DependencyObject obj)
        {
            return (string)obj.GetValue(VerticalOffsetProperty);
        }
        public static void SetVerticalOffset(DependencyObject obj, object value)
        {
            obj.SetValue(VerticalOffsetProperty, value);
        }
        public static void VerticalOffsetPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Camera cam = o as Camera;
            ScrollViewer scroll = cam.Template.FindName("cameraViewer", cam) as ScrollViewer;
            double vertical = 0;
            if (e.NewValue is double)
            {
                vertical = (double)e.NewValue;
            }
            scroll.ScrollToVerticalOffset(vertical);
        }
        #endregion
    }

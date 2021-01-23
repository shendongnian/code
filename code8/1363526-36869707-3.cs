    public class CustomControl : Control
    {
        public static readonly DependencyProperty GeometryDataProperty =
            DependencyProperty.Register(
                "GeometryData", typeof(GeometryGroup), typeof(CustomControl));
        public GeometryGroup GeometryData
        {
            get { return (GeometryGroup)GetValue(GeometryDataProperty); }
            set { SetValue(GeometryDataProperty, value); }
        }
        static CustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl),
                new FrameworkPropertyMetadata(typeof(CustomControl)));
        }
        public CustomControl()
        {
            Build();
        }
        public void Build()
        {
            var curve = new GeometryGroup();
            curve.Children.Add(new LineGeometry(new Point(0, 0), new Point(20, 20)));
            curve.Children.Add(new LineGeometry(new Point(0, 20), new Point(20, 0)));
            GeometryData = curve;
        }
    }

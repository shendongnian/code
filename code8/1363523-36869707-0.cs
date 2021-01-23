    public class CustomControl : Control
    {
        static CustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl),
                new FrameworkPropertyMetadata(typeof(CustomControl)));
        }
        public CustomControl()
        {
            GeometryData = Build();
        }
        public static GeometryGroup Build()
        {
            var curve = new GeometryGroup();
            curve.Children.Add(new LineGeometry(new Point(0, 0), new Point(20, 20)));
            curve.Children.Add(new LineGeometry(new Point(0, 20), new Point(20, 0)));
            return curve;
        }
        ...
    }

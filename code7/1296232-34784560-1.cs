     public class CustomBox : Shape
    {
        private Brush _originalBrush;
        private double _originalThickness;
        protected override Geometry DefiningGeometry
        {
            get
            {
                
                var pathGeometry = new PathGeometry();
                pathGeometry.AddGeometry(new RectangleGeometry(new Rect(new Point(0, 0), new Point(200, 200))));
                var formattedText = new FormattedText("CustomBox", CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    new Typeface("Times New-Roman"), 14, Brushes.Black);
                var textGeometry = formattedText.BuildGeometry(new Point(0, 0));
                pathGeometry.AddGeometry(textGeometry);
                return pathGeometry;
            }
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            _originalThickness = StrokeThickness;
            StrokeThickness = 2;
            _originalBrush = Fill;
            Fill = Brushes.Aqua;
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            StrokeThickness = _originalThickness;
            Fill = _originalBrush;
        }
    }

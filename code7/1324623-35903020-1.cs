    public class CandlestickShape : Path
    {
        public double StartValue
        {
            get { return Convert.ToDouble(GetValue(StartValueProperty)); }
            set { SetValue(StartValueProperty, value); }
        }
        public static readonly DependencyProperty StartValueProperty =
            DependencyProperty.Register("StartValue", typeof(double), typeof(CandlestickShape), new PropertyMetadata(0));
        public double EndValue
        {
            get { return Convert.ToDouble(GetValue(EndValueProperty)); }
            set { SetValue(EndValueProperty, value); }
        }
        public static readonly DependencyProperty EndValueProperty =
            DependencyProperty.Register("EndValue", typeof(double), typeof(CandlestickShape), new PropertyMetadata(0));
        public double MinValue
        {
            get { return Convert.ToDouble(GetValue(MinValueProperty)); }
            set { SetValue(MinValueProperty, value); }
        }
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(CandlestickShape), new PropertyMetadata(0));
        public double MaxValue
        {
            get { return Convert.ToDouble(GetValue(MaxValueProperty)); }
            set { SetValue(MaxValueProperty, value); }
        }
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(CandlestickShape), new PropertyMetadata(0));
        /// <summary>
        /// Defines how many Pixel should be drawn for one Point
        /// </summary>
        public double PixelPerPoint
        {
            get { return Convert.ToDouble(GetValue(PointsPerPixelProperty)); }
            set { SetValue(PointsPerPixelProperty, value); }
        }
        public static readonly DependencyProperty PointsPerPixelProperty =
            DependencyProperty.Register("PixelPerPoint", typeof(double), typeof(CandlestickShape), new PropertyMetadata(0));
        public CandlestickShape()
        {
            this.RegisterPropertyChangedCallback(CandlestickShape.WidthProperty, new DependencyPropertyChangedCallback(RenderAffectingPropertyChanged));
            this.RegisterPropertyChangedCallback(CandlestickShape.StartValueProperty, new DependencyPropertyChangedCallback(RenderAffectingPropertyChanged));
            this.RegisterPropertyChangedCallback(CandlestickShape.EndValueProperty, new DependencyPropertyChangedCallback(RenderAffectingPropertyChanged));
            this.RegisterPropertyChangedCallback(CandlestickShape.MinValueProperty, new DependencyPropertyChangedCallback(RenderAffectingPropertyChanged));
            this.RegisterPropertyChangedCallback(CandlestickShape.MaxValueProperty, new DependencyPropertyChangedCallback(RenderAffectingPropertyChanged));
            this.RegisterPropertyChangedCallback(CandlestickShape.PointsPerPixelProperty, new DependencyPropertyChangedCallback(RenderAffectingPropertyChanged));
        }
        private void RenderAffectingPropertyChanged(DependencyObject o, DependencyProperty e)
        {
            (o as CandlestickShape)?.SetRenderData();
        }
        private void SetRenderData()
        {
            var maxBorderValue = Math.Max(this.StartValue, this.EndValue);
            var minBorderValue = Math.Min(this.StartValue, this.EndValue);
            double topLineLength = (this.MaxValue - maxBorderValue) * this.PixelPerPoint;
            double bottomLineLength = (minBorderValue - this.MinValue) * this.PixelPerPoint;
            double bodyLength = (this.EndValue - this.StartValue) * this.PixelPerPoint;
            var fillColor = new SolidColorBrush(Colors.Green);
            if (bodyLength < 0)
                fillColor = new SolidColorBrush(Colors.Red);
            bodyLength = Math.Abs(bodyLength);
            var bodyGeometry = new RectangleGeometry
            {
                Rect = new Rect(new Point(0, topLineLength), new Point(this.Width, topLineLength + bodyLength)),
            };
            var topLineGeometry = new LineGeometry
            {
                StartPoint = new Point(this.Width / 2, 0),
                EndPoint = new Point(this.Width / 2, topLineLength)
            };
            var bottomLineGeometry = new LineGeometry
            {
                StartPoint = new Point(this.Width / 2, topLineLength + bodyLength),
                EndPoint = new Point(this.Width / 2, topLineLength + bodyLength + bottomLineLength)
            };
            this.Data = new GeometryGroup
            {
                Children = new GeometryCollection
                {
                    bodyGeometry,
                    topLineGeometry,
                    bottomLineGeometry
                }
            };
            this.Fill = fillColor;
            this.Stroke = new SolidColorBrush(Colors.Black);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            double height = (MaxValue - MinValue) * PixelPerPoint;
            return new Size(this.Width, height);
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            double height = (MaxValue - MinValue) * PixelPerPoint;
            return new Size(this.Width, height);
        }
    }

    public class CustomCanvas : Canvas
    {
        private readonly Pen pen = new Pen(Brushes.Red, 0d);
        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register(
                "Thickness", typeof(double), typeof(CustomCanvas),
                new PropertyMetadata(ThicknessPropertyChanged));
        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            var myRect = ...
            drawingContext.DrawRectangle(null, pen, myRect);
        }
        private static void ThicknessPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((CustomCanvas)obj).pen.Thickness = (double)e.NewValue;
        }
    }

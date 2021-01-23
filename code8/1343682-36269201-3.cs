    public class CircleText : FrameworkElement {
        public string[] Labels
        {
            get { return (string[])GetValue(LabelsProperty); }
            set { SetValue(LabelsProperty, value); }
        }
        
        public static readonly DependencyProperty LabelsProperty =
            DependencyProperty.Register("Labels", typeof(string[]), typeof(CircleText), new PropertyMetadata(null, OnLabelsChanged));
        private static void OnLabelsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((CircleText) d).InvalidateVisual();
        }
        protected override void OnRender(DrawingContext drawingContext) {
            if (Labels == null || Labels.Length == 0)
                return;
            var centerX = this.ActualWidth / 2;
            var centerY = this.ActualHeight / 2;
            var rad = Math.Min(this.ActualWidth / 2, this.ActualHeight / 2);
            for (int i = 0; i < Labels.Length; i++) {
                var angle = 360 / (Labels.Length) * i;
                var x = centerX + rad * Math.Cos(angle * Math.PI / 180.0);
                var y = centerY + rad * Math.Sin(angle * Math.PI / 180.0);
                FormattedText text = new FormattedText(
                    Labels[i],
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface("Verdana"),
                    12,
                    Brushes.Black);
                x -= text.Width / 2;
                y -= text.Height / 2;
                drawingContext.DrawText(text, new Point(x, y));
            }
            
        }
    }

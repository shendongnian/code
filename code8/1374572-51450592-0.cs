    public class WatermarkBehavior : Behavior<ComboBox>
    {
        private WaterMarkAdorner adorner;
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WatermarkBehavior), new PropertyMetadata("Watermark"));
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(double), typeof(WatermarkBehavior), new PropertyMetadata(12.0));
        public System.Windows.Media.Brush Foreground
        {
            get { return (System.Windows.Media.Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(System.Windows.Media.Brush), typeof(WatermarkBehavior), new PropertyMetadata(System.Windows.Media.Brushes.Black));
        
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }
     
        public static readonly DependencyProperty FontFamilyProperty =
            DependencyProperty.Register("FontFamily", typeof(string), typeof(WatermarkBehavior), new PropertyMetadata("Segoe UI"));
        public Thickness Margin
        {
            get { return (Thickness)GetValue(MarginProperty); }
            set { SetValue(MarginProperty, value); }
        }
        public static readonly DependencyProperty MarginProperty =
            DependencyProperty.Register("Margin", typeof(Thickness), typeof(WatermarkBehavior));
        protected override void OnAttached()
        {
            adorner = new WaterMarkAdorner(this.AssociatedObject, this.Text, this.FontSize, this.FontFamily, this.Margin, this.Foreground);
            this.AssociatedObject.Loaded += this.OnLoaded;
            this.AssociatedObject.GotFocus += this.OnFocus;
            this.AssociatedObject.LostFocus += this.OnLostFocus;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!this.AssociatedObject.IsFocused)
            {
                if (String.IsNullOrEmpty(this.AssociatedObject.Text))
                {
                    var layer = AdornerLayer.GetAdornerLayer(this.AssociatedObject);
                    layer.Add(adorner);
                }
            }
        }
        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.AssociatedObject.Text))
            {
                try
                {
                    var layer = AdornerLayer.GetAdornerLayer(this.AssociatedObject);
                    layer.Add(adorner);
                }
                catch { }
            }
        }
        private void OnFocus(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.SelectedItem != null)
            {
                var layer = AdornerLayer.GetAdornerLayer(this.AssociatedObject);
                layer.Remove(adorner);
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
        public class WaterMarkAdorner : Adorner
        {
            private string text;
            private double fontSize;
            private string fontFamily;
            private System.Windows.Media.Brush foreground;
            public WaterMarkAdorner(UIElement element, string text, double fontsize, string font, Thickness margin, System.Windows.Media.Brush foreground)
                : base(element)
            {
                this.IsHitTestVisible = false;
                this.Opacity = 0.6;
                this.text = text;
                this.fontSize = fontsize;
                this.fontFamily = font;
                this.foreground = foreground;
                this.Margin = margin;
            }
            protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);
                Matrix m = PresentationSource.FromVisual(Application.Current.MainWindow).CompositionTarget.TransformToDevice;
                
                var text = new FormattedText(
                        this.text,
                        System.Globalization.CultureInfo.CurrentCulture,
                        System.Windows.FlowDirection.LeftToRight,
                        new Typeface(fontFamily),
                        fontSize,
                        foreground, m.M11);
                
                drawingContext.DrawText(text, new System.Windows.Point(3, 3));
            }
        }
    }

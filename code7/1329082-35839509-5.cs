    public static class ButtonsHelper
    {
        public static readonly DependencyProperty MarkerColorProperty
            = DependencyProperty.RegisterAttached("MarkerColor", typeof(Brush), typeof(ButtonsHelper), new FrameworkPropertyMetadata(Brushes.Transparent));
    
        public static void SetMarkerColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(MarkerColorProperty, value);
        }
    
        public static Brush GetMarkerColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MarkerColorProperty);
        }
    
        public static readonly DependencyProperty MarkerWidthProperty
            = DependencyProperty.RegisterAttached("MarkerWidth", typeof(double), typeof(ButtonsHelper), new FrameworkPropertyMetadata(15d));
    
        public static void SetMarkerWidth(DependencyObject obj, double value)
        {
            obj.SetValue(MarkerWidthProperty, value);
        }
    
        public static double GetMarkerWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(MarkerWidthProperty);
        }
    }

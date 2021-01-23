    public class ScrollViewWatcher
    {
        public static readonly DependencyProperty HorizontalButtonVisibility = DependencyProperty.RegisterAttached(
           "HorizontalButtonVisibility",
           typeof(Visibility),
           typeof(ScrollViewWatcher),
           new FrameworkPropertyMetadata(Visibility.Visible,
               FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure)
         );
    
        public static Visibility GetHorizontalButtonVisiblity(UIElement element)
        {
            return (Visibility)element.GetValue(HorizontalButtonVisibility);
        }
    
        public static void SetHorizontalButtonVisibility(UIElement element, Visibility value)
        {
            element.SetValue(HorizontalButtonVisibility, value);
    
            ScrollViewer sv = element as ScrollViewer;
            if (sv != null)
            {
                sv.ScrollChanged -= sv_ScrollChanged;
                sv.ScrollChanged += sv_ScrollChanged;
            }
        }
    
        static void sv_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var sv = sender as ScrollViewer;
            if (sv != null)
            {
                var vis = sv.ExtentHeight > sv.ViewportWidth ? Visibility.Visible : Visibility.Hidden;
                sv.SetValue(HorizontalButtonVisibility, vis);
            }
        }
    }

    namespace CSharpWPF
    {
        public class AdvancedZooming : DependencyObject
        {
            public static bool GetKeepInCenter(DependencyObject obj)
            {
                return (bool)obj.GetValue(KeepInCenterProperty);
            }
            public static void SetKeepInCenter(DependencyObject obj, bool value)
            {
                obj.SetValue(KeepInCenterProperty, value);
            }
            // Using a DependencyProperty as the backing store for KeepInCenter.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty KeepInCenterProperty =
                DependencyProperty.RegisterAttached("KeepInCenter", typeof(bool), typeof(AdvancedZooming), new PropertyMetadata(false, OnKeepInCenterChanged));
            // Using a DependencyProperty as the backing store for Behavior.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty BehaviorProperty =
                DependencyProperty.RegisterAttached("Behavior", typeof(AdvancedZooming), typeof(AdvancedZooming), new PropertyMetadata(null));
            private static void OnKeepInCenterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ScrollViewer scroll = d as ScrollViewer;
                if ((bool)e.NewValue)
                {
                    //attach the behavior
                    AdvancedZooming behavior = new AdvancedZooming();
                    scroll.ScrollChanged += behavior.scroll_ScrollChanged;
                    scroll.SetValue(BehaviorProperty, behavior);
                }
                else
                {
                    //dettach the behavior
                    AdvancedZooming behavior = scroll.GetValue(BehaviorProperty) as AdvancedZooming;
                    if (behavior != null)
                        scroll.ScrollChanged -= behavior.scroll_ScrollChanged;
                    scroll.SetValue(BehaviorProperty, null);
                }
            }
            //variables to store the offset values
            double relX;
            double relY;
            void scroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
            {
                ScrollViewer scroll = sender as ScrollViewer;
                //see if the content size is changed
                if (e.ExtentWidthChange != 0 || e.ExtentHeightChange != 0)
                {
                    //calculate and set accordingly
                    scroll.ScrollToHorizontalOffset(CalculateOffset(e.ExtentWidth, e.ViewportWidth, scroll.ScrollableWidth, relX));
                    scroll.ScrollToVerticalOffset(CalculateOffset(e.ExtentHeight, e.ViewportHeight, scroll.ScrollableHeight, relY));
                }
                else
                {
                    //store the relative values if normal scroll
                    relX = (e.HorizontalOffset + 0.5 * e.ViewportWidth) / e.ExtentWidth;
                    relY = (e.VerticalOffset + 0.5 * e.ViewportHeight) / e.ExtentHeight;
                }
            }
            private static double CalculateOffset(double extent, double viewPort, double scrollWidth, double relBefore)
            {
                //calculate the new offset
                double offset = relBefore * extent - 0.5 * viewPort;
                //see if it is negative because of initial values
                if (offset < 0)
                {
                    //center the content
                    //this can be set to 0 if center by default is not needed
                    offset = 0.5 * scrollWidth;
                }
                return offset;
            }
        }
    }

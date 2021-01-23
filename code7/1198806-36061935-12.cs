    public static class Adorning
    {
        public static Brush GetStroke(DependencyObject obj)
        {
            return (Brush)obj.GetValue(StrokeProperty);
        }
        public static void SetStroke(DependencyObject obj, Brush value)
        {
            obj.SetValue(StrokeProperty, value);
        }
        // Using a DependencyProperty as the backing store for Stroke. This enables animation, styling, binding, etc...  
        public static readonly DependencyProperty StrokeProperty =
        DependencyProperty.RegisterAttached("Stroke", typeof(Brush), typeof(Adorning), new PropertyMetadata(Brushes.Transparent, strokeChanged));
    
        private static void strokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var stroke= e.NewValue as Brush;
            ensureAdorner(d,a=>a.Stroke=stroke);
        }
    
        private static void ensureAdorner(DependencyObject d, Action<StrokeAdorner> action)
        {
            var tb = d as TextBlock;
            if (tb == null) throw new Exception("StrokeAdorner only works on TextBlocks");
            EventHandler f = null;
            f = new EventHandler((o, e) =>
              {
                  var adornerLayer = AdornerLayer.GetAdornerLayer(tb);
                  if (adornerLayer == null) throw new Exception("AdornerLayer should not be empty");
                  var adorners = adornerLayer.GetAdorners(tb);
                  var adorner = adorners == null ? null : adorners.OfType<StrokeAdorner>().FirstOrDefault();
                  if (adorner == null)
                  {
                      adorner = new StrokeAdorner(tb);
                      adornerLayer.Add(adorner);
                  }
                  tb.LayoutUpdated -= f;
                  action(adorner);
              });
            tb.LayoutUpdated += f;
        }
    
        public static double GetStrokeThickness(DependencyObject obj)
        {
            return (double)obj.GetValue(StrokeThicknessProperty);
        }
        public static void SetStrokeThickness(DependencyObject obj, double value)
        {
            obj.SetValue(StrokeThicknessProperty, value);
        }
        // Using a DependencyProperty as the backing store for StrokeThickness. This enables animation, styling, binding, etc...  
        public static readonly DependencyProperty StrokeThicknessProperty =
        DependencyProperty.RegisterAttached("StrokeThickness", typeof(double), typeof(Adorning), new PropertyMetadata(0.0, strokeThicknessChanged));
    
        private static void strokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ensureAdorner(d, a =>
            {
                if (DependencyProperty.UnsetValue.Equals(e.NewValue)) return;
                a.StrokeThickness = (ushort)(double)e.NewValue;
            });
        }
    }

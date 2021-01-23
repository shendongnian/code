    public class WeightedPanel : Panel
    {
        public static double GetWeight(DependencyObject obj)
        {
            return (double)obj.GetValue(WeightProperty);
        }
        public static void SetWeight(DependencyObject obj, double value)
        {
            obj.SetValue(WeightProperty, value);
        }
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.RegisterAttached("Weight", typeof(double), typeof(WeightedPanel), new PropertyMetadata(1.0));
        private double totalWeight_;
        protected override Size MeasureOverride(Size availableSize)
        {
            totalWeight_ = 0;
            foreach (UIElement child in InternalChildren)
            {
                totalWeight_ += WeightedPanel.GetWeight(child);
                child.Measure(availableSize);
            }
            return new Size(0, 0);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            double offset = 0;
            foreach (UIElement child in InternalChildren)
            {
                var weight = WeightedPanel.GetWeight(child);
                var height = finalSize.Height * weight / totalWeight_;
                child.Arrange(new Rect(new Point(0, offset), new Size(finalSize.Width, height)));
                offset += height;
            }
            return finalSize;
        }
    }

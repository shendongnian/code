    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using Xceed.Wpf.Toolkit;
    namespace WpfApplication13
    {
    class RestrictedDoubleUpDown: DoubleUpDown
    {
        public DoubleCollection Range
        {
            get { return (DoubleCollection)GetValue(RangeProperty); }
            set { SetValue(RangeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Range.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RangeProperty =
            DependencyProperty.Register("Range", typeof(DoubleCollection), typeof(RestrictedDoubleUpDown),
                new FrameworkPropertyMetadata(new DoubleCollection(), OnRangeChanged));
        private static void OnRangeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = (RestrictedDoubleUpDown)d;
            if(self.Range!=null)
                self.Value = self.Range.FirstOrDefault();
        }
        private int currentIndex = 0;
        protected override double IncrementValue(double value, double increment)
        {
            if (currentIndex < Range.Count - 1)
                currentIndex++;
            return Range[currentIndex];
        }
        protected override double DecrementValue(double value, double increment)
        {
            if (currentIndex > 0)
                currentIndex--;
            return Range[currentIndex];
        }
         
    }

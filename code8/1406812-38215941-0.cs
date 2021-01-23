    public class IntToVisibilityConverter : IValueConverter
    {
        public IntToVisibilityConverter()
        {
            FalseVisibility = Visibility.Collapsed;
            Negate = false;
            VisibilityThreshold = 0;
        }
        public object Convert(object valueObject, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double value = (double)valueObject;
            bool isVisible;
            if (value < VisibilityThreshold)
            {
                isVisible = false;
            }
            else
            {
                isVisible = true;
            }
            isVisible = Negate ? !isVisible : isVisible;
            if (isVisible)
            {
                //System.Diagnostics.Debug.WriteLine("isVisible");
                return Visibility.Visible;
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("NOT isVisible");
                return FalseVisibility;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility? val = null;
            if (value is Visibility) val = (Visibility)value;
            if (!val.HasValue) return value;
            bool result = val == Visibility.Visible;
            result = Negate ? !result : result;
            if (result)
            {
                return VisibilityThreshold;
            }
            else
            {
                return VisibilityThreshold - 1;
            }
        }
        public bool Negate { get; set; }
        public double VisibilityThreshold { get; set; }
        public Visibility FalseVisibility { get; set; }
    }

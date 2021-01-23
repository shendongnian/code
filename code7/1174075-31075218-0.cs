    public static class Extensions
    {
        public static System.Windows.Visibility Reversed(this System.Windows.Visibility visibility)
        {
            if (visibility == System.Windows.Visibility.Visible)
                visibility = System.Windows.Visibility.Collapsed;
            else if (visibility == System.Windows.Visibility.Collapsed || visibility == System.Windows.Visibility.Hidden)
                visibility = System.Windows.Visibility.Visible;
            return visibility;
        }
    }
    public class VisibilityReversedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((System.Windows.Visibility)value).Reversed();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((System.Windows.Visibility)value).Reversed();
        }
    }

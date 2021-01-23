    public class TruncateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                double truncated;
                if (Double.TryParse(value, out truncated))
                {
                    return ((double)((int)(truncated * 1000.0))) / 1000.0;
                }
            }
            return string.Empty;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

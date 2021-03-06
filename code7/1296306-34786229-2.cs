    public class NullValueConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? value : DependencyProperty.UnsetValue;
        }
        ...
    }
    

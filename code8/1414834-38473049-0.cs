    public class StringLengthLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            string val = value.ToString();
            int length = parameter as int? ?? 5;
            if (val.Length > length)
                return val.Substring(0, length);
            return val;
        }
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

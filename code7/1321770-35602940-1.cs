    public class EnStatusEnum Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((enStatus)value).ToString()
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return  null;
        }
    }

    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(Application.DateFormat, value);
        }
            
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
        }
    }

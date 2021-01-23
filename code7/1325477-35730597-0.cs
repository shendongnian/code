    public class NameValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Students)
            {
                return (value as Students).Name;
            }
            if (value is Classes)
            {
                return (value as Classes).ClassName;
            }
            if (value is Cars)
            {
                return (value as Cars).CarType;
            }
            return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

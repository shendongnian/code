    public class HasPropertyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
    
            if (parameter == null)
            {
                return false;
            }
    
            PropertyInfo property = value.GetType().GetProperty(parameter.ToString());
            return property != null;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

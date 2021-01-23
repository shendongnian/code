    public class GeneralEnumConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.GetType().IsEnum)
            {
                return value.ToString();
            }
            return null;
        }
        private string FormatEnumName(string enumName)
        {
            return enumName.Replace('_', ' ');
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

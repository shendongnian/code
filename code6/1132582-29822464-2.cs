    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, 
               object parameter, System.Globalization.CultureInfo culture)
        {
             property1 = values[0];
             property2 = values[1];
             // Do your logic with the properties here.
        }
        public object[] ConvertBack(object value, Type[] targetTypes, 
               object parameter, System.Globalization.CultureInfo culture)
        {
        }
    }

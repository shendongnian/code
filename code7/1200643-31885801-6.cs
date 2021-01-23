    public class ConverterName : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, 
               object parameter, System.Globalization.CultureInfo culture)
        {
            //Check your binded values and return the string you want to.
           // values is an array of items binded in xaml.
        }
        public object[] ConvertBack(object value, Type[] targetTypes, 
               object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

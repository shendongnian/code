    public class LargeRunConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double input = ((double) value) * 1000;
            double decimalPart = input - Math.Truncate(input);
            decimalPart = decimalPart * 100;
            return string.Format("{0:00}", decimalPart);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

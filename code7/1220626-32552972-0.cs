    [ValueConversion(typeof(double), typeof(double))]
    public class RatioConveter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (System.Convert.ToDouble(values[0]) * System.Convert.ToDouble(values[1])) / System.Convert.ToDouble(values[2]);
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

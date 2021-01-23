    [ValueConversion(typeof(Double), typeof(String))]
    public class DoubleToStringValueConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              System.Globalization.CultureInfo culture)
        {
            decimal display = Math.Round(System.Convert.ToDecimal((double)value), 10) / 1.000000000000000000000000000000000m;
            value = System.Convert.ToDouble(display);
            string res = display.ToString(culture);
            return res;
        }
        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            string val = value as string;
            double res = 0d;
            double.TryParse(val, System.Globalization.NumberStyles.Float, culture, out res);
            return res;
        }
    }

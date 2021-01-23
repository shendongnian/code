    public class VoltageToString: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            return ((int)value).ToString() + " kV";
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            return int.Parse((string).Replace(" kV",""));
        }
    }

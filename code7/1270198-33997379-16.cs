    public class HeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool enableEdit = (bool)value;
            double param = System.Convert.ToDouble(parameter);
            if (enableEdit)
                return new GridLength(param, GridUnitType.Star);
            else
                return new GridLength(0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class HeightMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool enableEdit = (bool)values[0];
            double param = System.Convert.ToDouble(values[1]);
            if (enableEdit)
                return new GridLength(param, GridUnitType.Star);
            else
                return new GridLength(0);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

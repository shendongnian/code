    public class DateTimeToSentinalDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToDateTime(value).Equals(new DateTime(1900, 1, 1, 0, 0, 0)))
            {
                return null;
            }
            else
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return new DateTime(1900, 1, 1, 0, 0, 0);
            }
            else
            {
                return value;
            }
        }
    }

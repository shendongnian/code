    public class IndexToXYZOrHaHaHaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = (int) value;
            if (index > 10)
            {
                return "XYZ";
            }
            return "HaHaHa";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

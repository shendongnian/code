    class OffsetValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int offset = int.Parse((string)parameter);
            return (int)value - offset;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int offset = int.Parse((string)parameter);
            return (int)value + offset;
        }
    }

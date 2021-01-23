    class MyCloneConverter : IValueConverter
    {
        public static MyCloneConverter Instance = new MyCloneConverter();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Freezable)
            {
                value = (value as Freezable).Clone();
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

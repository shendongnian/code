    class ThicknessToStartPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is double))
            {
                return Binding.DoNothing;
            }
            // Need to start the arc in the middle of the intended stroke
            return new Point(10, ((double)value) / 2);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class ThicknessToSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is double))
            {
                return Binding.DoNothing;
            }
            double widthHeight = 10 - ((double)value) / 2;
            return new Size(widthHeight, widthHeight);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

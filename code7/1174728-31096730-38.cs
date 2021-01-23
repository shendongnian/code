        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var colorStr = value.ToString();
            var color = (Color)System.Windows.Media.ColorConverter.ConvertFromString(colorStr);
            return new SolidColorBrush(color);
        }

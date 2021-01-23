    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is YourEnum)
            {
                var color = (YourEnum)value;
                switch (color)
                {
                    case YourEnum.Blue:
                        return new SolidColorBrush(Colors.Blue);
                    case YourEnum.Red:
                        return new SolidColorBrush( Colors.Red);
                    case YourEnum.Green:
                        return new SolidColorBrush( Colors.Green);
                }
            }
            return SystemColors.ControlColor;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

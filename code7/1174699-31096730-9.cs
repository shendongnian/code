    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
                var color = value.ToString();
                switch (color)
                {
                    case "Blue":
                        return new SolidColorBrush(Colors.Blue);
                    case "Red":
                        return new SolidColorBrush(Colors.Red);
                    case "Green":
                        return new SolidColorBrush(Colors.Green);
                }
            
            return SystemColors.ControlColor;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

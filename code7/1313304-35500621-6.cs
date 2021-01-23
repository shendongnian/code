    public class EllipseStrokeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = new SolidColorBrush(Colors.Blue);
            if ((bool)value)
            {
                result = new SolidColorBrush(Colors.Red);
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

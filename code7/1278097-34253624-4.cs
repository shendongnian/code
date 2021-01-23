    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value) ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new Exception("Not Implemented");
        }
    }

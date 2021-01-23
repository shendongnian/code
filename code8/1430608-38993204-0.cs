    public class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolValue = (bool)value;
            return !boolValue;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var boolValue = (bool)value;
            return !boolValue;
        }
    }

    public class GenericConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // no convert to a specific type needed -> the "value" is already an instance of the correct type.
            return value;
        }
    }

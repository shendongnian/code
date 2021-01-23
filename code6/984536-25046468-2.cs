    public class NullableIntToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString())) return null;
            int result;
            if (int.TryParse(value.ToString(), out result)) return result;
            return null;
        }
    }

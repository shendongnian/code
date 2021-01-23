<!-- -->
    public class KeyValueConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new KeyValuePair<string, object>((string)parameter, value);
        }
    }
    public class DictionaryMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] keyValues, Type targetType, object parameter, CultureInfo culture)
        {
            return keyValues.Cast<KeyValuePair<string, object>>()
                            .ToDictionary(i => i.Key, i => i.Value);
        }
    }

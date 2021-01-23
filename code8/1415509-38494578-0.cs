    public sealed class StringFormatConverter : IValueConverter
    {
        public int MaxLength { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            if (parameter == null)
                return value;
            var result = string.Format((string)parameter, value);
            
            if (MaxLength > 0)
                result = result.Substring(0, MaxLength);
            
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
            string language)
        {
            throw new NotImplementedException();
        }
    }

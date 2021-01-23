    public class BoolToStringConverter : IValueConverter
    {
        public string TrueString { get; set; }
        public string FalseString { get; set; }
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool)value;
    
            return boolValue ? TrueString : FalseString;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

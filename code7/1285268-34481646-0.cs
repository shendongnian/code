    [ValueConversion(typeof(byte), typeof(string))]
    public class HexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte byteValue = (byte)value;
            return byteValue.ToString("X", culture);
                
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte byteValue;
            string stringValue = (string)value;
            if (String.IsNullOrEmpty(stringValue))
            {
                return 0;
            }
    
            if (Byte.TryParse(stringValue, NumberStyles.AllowHexSpecifier, culture, out byteValue))
            {
                return byteValue;
            }
    
            return DependencyProperty.UnsetValue;
        }
    }

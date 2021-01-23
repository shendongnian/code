    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            return GetBrushFromString(value as string)
        }
     
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            Throw new SomeException();
        }
    }

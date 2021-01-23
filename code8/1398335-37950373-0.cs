    public class SortedListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SortedList<string, string> data = (SortedList<string, string>)value;
            String parame = (String)parameter;
            return data[parame];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

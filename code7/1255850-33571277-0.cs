    public class Converter : IMultiValueConverter
    {
        public Converter()
        {
        }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var currentPersonName = values[0].ToString();
            var listItemPersonName = values[1].ToString();
            return currentPersonName == listItemPersonName ? Brushes.Red : Brushes.Black;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

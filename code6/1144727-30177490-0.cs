    public class ClipboardConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, 
                      System.Globalization.CultureInfo culture) {
            return Clipboard.GetData(value as string);
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                      System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

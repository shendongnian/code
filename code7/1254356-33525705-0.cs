    public class Col1Converter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var result = (RowObject)value;
            Color color;
            if (result.Value < 0) {
                color = Colors.Red;
            }
            else if (result.Value == 0) {
                color = Colors.Yellow;
            }
            else {
                color = Colors.Green;
            }
            return new SolidColorBrush(color);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    

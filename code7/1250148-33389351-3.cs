        public class StringToColorConverter: IValueConverter
        {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
         string contentvalue=value.ToString();
            var result = (contentvalue.Equals("something")) ? Brushes.Green : Brushes.Red;
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
        }

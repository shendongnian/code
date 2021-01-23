        public class ItalicConverter : IValueConverter
        {
             public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
             {
                return "Italic";
             }
             public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
             {
                return true;
             }
         }

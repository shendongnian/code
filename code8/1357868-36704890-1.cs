    public class CountToWidthConverter : IValueConverter
        {
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                     var tabCount = (int)value;
                     var tabWidth = 1000/tabCount;
                     return tabWidth;
                }
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                     ...
                           
                }
        }

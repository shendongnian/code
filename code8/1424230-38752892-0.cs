    [ValueConversion(typeof(bool), typeof(System.Windows.Media.Color))]
    public class IsLeftToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? System.Windows.Media.Color.Green : System.Windows.Media.Color.Red
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

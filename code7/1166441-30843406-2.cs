     public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            if(val)
            {
                return Visibility.Visible;
            }
            else
            {
               return Visibility.Hidden;
            }
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }
    }

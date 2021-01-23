    public class BooleanToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isChecked = false;
            if (bool.TryParse(value.ToString(), out isChecked))
            {
                return isChecked ? Visibility.Visible : Visibility.Collapsed;
            }
            return visibility;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

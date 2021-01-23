    class Button1VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targettype, object parameter, System.Globalization.CultureInfo culture)
        {
            int mode = (int)value;
            if (mode <= (int)parameter)
                return System.Windows.Visibility.Collapsed;
            else
                return System.Windows.Visibility.Visible;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

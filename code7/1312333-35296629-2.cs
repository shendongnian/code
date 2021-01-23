    [ValueConversion(typeof(AppMode), typeof(bool))]
    public class AppModeEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedMode = (AppMode)value;
            var enabledModes = (AppMode)parameter;
            return 0 != (selectedMode & enabledModes);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

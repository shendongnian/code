    public class EnumToDisplayName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try 
            {
                var enumValue = (CoolEnum)value;
                return enumValue.DisplayName();
            }
            catch (Exception){
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }

    internal sealed class OilLevelConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var percentage = (decimal) value;
            var maxLevel = System.Convert.ToInt32((string) parameter);
            var currentLevel = System.Convert.ToInt32(maxLevel * percentage);
            return currentLevel;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

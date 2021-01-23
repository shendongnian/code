    public class Converters : IValueConverter
    {
        private static readonly PropertyInfo InheritanceContextProp = typeof(DependencyObject).GetProperty("InheritanceContext", BindingFlags.NonPublic | BindingFlags.Instance);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dic = value as Dictionary<string, DateTime>;
            return dic.Values;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

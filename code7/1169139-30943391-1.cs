    public class FormatStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue || values[0] == null)
                return String.Empty;
            var format = (string)values[0];
            var args = values.Where((o, i) => { return i != 0; }).ToArray();
            return String.Format(format, args);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(string[]), typeof(TextDecorations))]
    public class DecorationsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as string[];
            if (source == null)
                return DependencyProperty.UnsetValue;
            return source.Contains(parameter as string) ? null : TextDecorations.Strikethrough;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

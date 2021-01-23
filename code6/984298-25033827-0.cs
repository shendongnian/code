    public class EmptyStringToCollapsedConverter : IValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = (value as string);
            return String.IsNullOrWhiteSpace(s)? Visibility.Collapsed : Visibility.Visible;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

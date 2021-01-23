    public class StateToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public StateToVisibilityConverter() { }
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (WindowState)value == WindowState.Maximized;
            if ((string)parameter == "Invert")
                result = !result;
            return result ? Visibility.Visible : Visibility.Hidden;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }
    }

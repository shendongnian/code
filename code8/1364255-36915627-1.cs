    public class ValueAddConverter : MarkupExtension, IValueConverter
    {
        public ValueAddConverter() { }
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (double)value + double.Parse((string)parameter, NumberFormatInfo.InvariantInfo);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

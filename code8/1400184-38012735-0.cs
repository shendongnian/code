    public class RuntimeConverter : MarkupExtension, IValueConverter
    {
        public object FallbackValue { get; set; }
        public IValueConverter Converter { get; set; }
        public RuntimeConverter() { }
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return FallbackValue;
            if (Converter == null)
                return value;
            return Converter.Convert(value, targetType, parameter, culture);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return FallbackValue;
            if (Converter == null)
                return value;
            return Converter.ConvertBack(value, targetType, parameter, culture);
        }
    }

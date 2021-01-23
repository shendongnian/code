    namespace MyProject.Converters
    {
        public class IntToBool : IValueConverter, MarkupExtension
        {
            public override object ProvideValue(IServiceProvider serviceProvider) => this;
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) != 0;
        }
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? 1 : 0;
        }
    }

    public class MultiValueConverterExtension : MarkupExtension, IMultiValueConverter {
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return values[1];
        }
        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
            return new object[] { value, value };
        }
    }

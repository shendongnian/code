    class ComboboxEmptyValueConverterExtension : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = values[0] as string;
            var dataContext = values[1] as Model;
            return (stringValue != null && String.IsNullOrEmpty(stringValue)) ? dataContext?.Name : values[0];
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { value, null };
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

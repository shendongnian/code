    // in current form it's actually BoolToColorRedGreenConverter
    public class BoolToColorConverter : MarkupExtension, IValueConverter
    {
        public BoolToColorConverter() { }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                var colorFalse = Colors.Green;
                var colorTrue = Colors.Red;
                if (parameter != null)
                {
                    //...
                }
                return (bool)value ? colorTrue : colorFalse;
            }
            throw new InvalidCastException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

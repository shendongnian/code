    public class SuperConverter : MarkupExtension, IValueConverter
    {
        public SuperConverter() { }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                bool inverted = false;
                if (parameter != null && parameter.ToString().Contains("Inverted"))
                    inverted = true;
                return (inverted && (bool)value || !inverted && !((bool)value)) ? Visibility.Hidden : Visibility.Visible;
            }
            throw new InvalidCastException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NullToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public Visibility NullValue { get; set; }
        public Visibility NotNullValue { get; set; }
        public NullToVisibilityConverter()
        {
            NullValue = Visibility.Collapsed;
            NotNullValue = Visibility.Visible;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return NullValue;
            return NotNullValue;
        }
    
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

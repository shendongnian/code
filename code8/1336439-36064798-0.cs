    public class MultiBindingConverter : MarkupExtension, IMultiValueConverter
        {
            public MultiBindingConverter() { }
        
            public override object ProvideValue(IServiceProvider serviceProvider) => this;
        
            object[] _old;
        
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                return ((bool)values[0] /*A */) || ((bool)values[1]/* B */);
            }
        
        
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
               return new object[] { (bool)value, (bool)value};
            }
    }

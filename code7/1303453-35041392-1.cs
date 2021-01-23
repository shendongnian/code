        public class CountToBoolConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if ((int)value != 4)
                    return true;
    
                return false;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        public class CountToBoolExtension : MarkupExtension
        {
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return new CountToBoolConverter();
            }
        }

    internal class MovieDisplayConverter : MarkupExtension, IValueConverter
        {
            private static MovieDisplayConverter converter;
    
            public MovieDisplayConverter()
            {
                
            }
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is MovieType)
                {
                    
    
                    switch ((MovieType)value)
                    {
                        case MovieType.Action:
                            return "Action Movie";
                        case MovieType.Horror:
                            return "Horror Movie";
                        default:
                            throw new ArgumentOutOfRangeException("value", value, null);
                    }
                }
                return value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return converter ?? (converter = new MovieDisplayConverter());
            }
        }

        [ValueConversion(typeof(string), typeof(string))]
        public class ScreenRatioConverter : MarkupExtension, IValueConverter
        {
                private static ScreenRatioConverter _instance;
        
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                { 
    
                    double size = System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);
                    return size.ToString("G0", CultureInfo.InvariantCulture);
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                { 
                    throw new NotImplementedException();
                }
        
                public override object ProvideValue(IServiceProvider serviceProvider)
                {
                    return _instance ?? (_instance = new ScreenRatioConverter());
                }
        
            }

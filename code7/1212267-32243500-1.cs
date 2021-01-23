    public class ErrorSeverityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Severity severity = (Severity)value;
    		switch(severity)
    		{
    			case Severity.Unknown:
    				return "/error.jpg";
    			
    			case Severity.Ok:
    				return "/ok.jpg";
    		}
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

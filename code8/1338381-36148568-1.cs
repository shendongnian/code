    public class TimeSpanFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return null;
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            TimeSpan span;
    
            if (TimeSpan.TryParse(value.ToString(), out span))
            {
                return span;
            }
            else
            {
                return "";
            }
        }
    }

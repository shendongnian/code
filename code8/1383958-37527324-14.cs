    public class TimeSpanFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                var timeSpan = TimeSpan.Parse(value.ToString());
    
                return timeSpan.ToString(@"mm\:ss");
            }
            else
            {
                return "00:00";
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

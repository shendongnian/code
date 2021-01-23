    public class DateTimeToCalendarDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value;
            if (date == new DateTime(0001, 01, 01))
            {
                return null;
            }
            return new DateTimeOffset?(date);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var dto = (DateTimeOffset)value;
            return dto.DateTime;
        }
    }

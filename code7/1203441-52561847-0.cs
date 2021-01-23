    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                DateTimeOffset dto = (DateTimeOffset)value;
                return dto.DateTime;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
                DateTime date = (DateTime)value;
                return new DateTimeOffset(date);
        }
    }

    public class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateValue = value as DateTime?;
            if (dateValue != null)
            {
                var diff = dateValue - DateTime.Now;
                // Greater than 1 year, format as MM/dd/yyyy
                if (diff > new TimeSpan(365, 0, 0, 0))
                {
                    return dateValue.Value.ToString("MMM dd yyyy");
                }
                else if (dateValue == DateTime.MinValue)
                {
                    return "";
                }
                else
                {
                    return dateValue.Value.ToString("MMM dd hh:mm");
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

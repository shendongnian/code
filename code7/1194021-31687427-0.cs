    class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                var test = (DateTime)value;
                if (test == DateTime.MinValue)
                {
                    return "None";
                }
                var date = test.ToString("MM/dd/yyyy hh:mm");
                return (date);
            }
    
            return string.Empty;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

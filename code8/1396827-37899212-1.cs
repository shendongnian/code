    public class JalaliDateConverter : IValueConverter
    {
        public Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           // Gregorian to Jalali conversion code
           return jalaliaDate;
        }
        public ConvertBack((object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Jalali to Gregorian conversion code
            return gregorianDate;
        }
    }

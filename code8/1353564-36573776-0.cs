    public class Week
    {
        public static implicit operator int(Week d)
        {
            var culture = CultureInfo.GetCultureInfo("se-SE");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);
            var dateTime = DateTime.Today;
            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
    
            return weekNumber;
        }
    }

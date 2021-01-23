    public static class DateTimeExtensions
    {
        public static int GetWeekOfYear(this DateTime date)
        {
            DateTimeFormatInfo dateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dateTimeFormatInfo.Calendar;
            var weekOfYear = calendar.GetWeekOfYear(date,
                                                    dateTimeFormatInfo.CalendarWeekRule,
                                                    dateTimeFormatInfo.FirstDayOfWeek);
            return weekOfYear;
        }
    }

    public static class DateFunctions
    {
        public static DateTime GetPreviousInstanceOfWeekDay(DateTime forDate, 
            DayOfWeek dayOfWeek)
        {
            return forDate.DayOfWeek >= dayOfWeek 
                ? forDate.AddDays(dayOfWeek - forDate.DayOfWeek).Date 
                : forDate.AddDays(-(7-(dayOfWeek - forDate.DayOfWeek))).Date;
        }
        public static IEnumerable<DateTime> GetDateRange(DateTime startDate, int length)
        {
            return Enumerable.Range(0, length - 1).Select(x => startDate.Date.AddDays(x));
        }
    }

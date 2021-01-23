    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime datetime, DayOfWeek startOfWeek)
        {
            int difference = datetime.DayOfWeek - startOfWeek;
            if (difference >= 0)
                return datetime.AddDays(-1 * difference).Date;
            difference += 7;
            return datetime.AddDays(-1 * difference).Date;
        }
    }

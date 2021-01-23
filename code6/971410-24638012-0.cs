    public static class Extensions
    {
        public static DateTime HourPart(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, 0, 0);
        }
    }

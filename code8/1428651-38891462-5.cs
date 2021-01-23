    public static class DateTimeExtensions
    {
        public static DateTime RoundDown(this DateTime dt, TimeSpan d)
        {
            return new DateTime(((dt.Ticks + 1) / d.Ticks) * d.Ticks);
        }
    }

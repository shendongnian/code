    DateTime.Compare(start.TrimMilliseconds(), stop.TrimMilliseconds())
    public static class DateTimeExtensions
    {
        public static DateTime TrimMilliseconds(this DateTime date)
        {
            return date.AddMilliseconds(-date.Millisecond);
        }
    }

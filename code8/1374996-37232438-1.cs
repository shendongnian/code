     public static class DateQueryExtensions
    {
        public static DateRangeQueryDescriptor<T> LessThanWithOption<T>(this DateRangeQueryDescriptor<T> q, DateMath to, bool includeEnd)
            where T : class
        {
            return includeEnd ? q.LessThanOrEquals(to) : q.LessThan(to);
        }
    }

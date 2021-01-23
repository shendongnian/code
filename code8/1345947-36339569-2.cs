    public static class UnixTimeExtensions
    {
        const long SecondsToMilliseconds = 1000L;
        const long MillisecondsToTicks = 10000L;
        static readonly DateTime utcEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public static DateTime FromUnixTimestamp(this long stamp)
        {
            return utcEpochStart.AddSeconds(stamp);
        }
        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            var span = dateTime.ToUniversalTime() - utcEpochStart;
            return span.Ticks / (SecondsToMilliseconds * MillisecondsToTicks);
        }
    }

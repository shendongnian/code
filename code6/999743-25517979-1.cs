    public static void SetSystemDateTimeSafely(DateTime timeToSet,
                                               bool withEarlierWhenAmbiguous = true)
    {
        TimeZoneInfo timeZone = TimeZoneInfo.Local;
        bool isAmbiguous = timeZone.IsAmbiguousTime(timeToSet);
        DateTime utcTimeToSet = timeToSet.ToUniversalTime();
        if (isAmbiguous && withEarlierWhenAmbiguous)
            utcTimeToSet = utcTimeToSet.AddHours(-1);
        
        TimeSpan offset = timeZone.GetUtcOffset(utcTimeToSet);
        TimeSpan offsetOneHourLater = timeZone.GetUtcOffset(utcTimeToSet.AddHours(1));
            
        if (offset != offsetOneHourLater)
        {
            TimeSpan currentOffset = timeZone.GetUtcOffset(DateTime.UtcNow);
            if (offset != currentOffset)
            {
                SetSystemDateTime(utcTimeToSet.AddHours(-1));
            }
        }
        SetSystemDateTime(utcTimeToSet);
    }
    private static void SetSystemDateTime(DateTime utcDateTime)
    {
        if (utcDateTime.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException();
        }
        SYSTEMTIME st = new SYSTEMTIME
        {
            wYear = (short)utcDateTime.Year,
            wMonth = (short)utcDateTime.Month,
            wDay = (short)utcDateTime.Day,
            wHour = (short)utcDateTime.Hour,
            wMinute = (short)utcDateTime.Minute,
            wSecond = (short)utcDateTime.Second,
            wMilliseconds = (short)utcDateTime.Millisecond
        };
        SetSystemTime(ref st);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetSystemTime(ref SYSTEMTIME st);

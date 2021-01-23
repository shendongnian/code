    public sealed class TimeRange
    {
        public TimeRange(string dateTimeString)
        {
            DateTime dateTime;
            if (DateTime.TryParseExact(dateTimeString, @"yyyy-M-d HH\:mm\:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                _start = dateTime;
                _end   = dateTime.AddSeconds(1);
            }
            else if (DateTime.TryParseExact(dateTimeString, @"yyyy-M-d HH\:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                _start = dateTime;
                _end   = dateTime.AddMinutes(1);
            }
            else if (DateTime.TryParseExact(dateTimeString, @"yyyy-M-d HH", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                _start = dateTime;
                _end   = dateTime.AddHours(1);
            }
            else if (DateTime.TryParseExact(dateTimeString, @"yyyy-M-d", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                _start = dateTime;
                _end   = dateTime.AddDays(1);
            }
            else if (DateTime.TryParseExact(dateTimeString, @"yyyy-M", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                _start = dateTime;
                _end =   dateTime.AddMonths(1);
            }
            else if (DateTime.TryParseExact(dateTimeString, @"yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                _start = dateTime;
                _end   = dateTime.AddYears(1);
            }
            else
            {
                throw new ArgumentException("date/time is invalid: " + dateTimeString, "dateTimeString");
            }
        }
        public DateTime Start
        {
            get
            {
                return _start;
            }
        }
        public DateTime ExclusiveEnd
        {
            get
            {
                return _end;
            }
        }
        private readonly DateTime _start;
        private readonly DateTime _end;
    }

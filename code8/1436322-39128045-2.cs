    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts the date from the server time to the UK time
        /// </summary>
        /// <param name="dateTime">The datetime object to convert</param>
        /// <param name="timeZoneId">The timezone to convert to</param>
        /// <returns></returns>
        public static DateTimeOffset ToZoneTime(this DateTime dateTime, string timeZoneId = "GMT Standard Time")
        {          
            // Get the timezones
            var currentTimeZone = TimeZoneInfo.Local;
            var targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            // Convert the supplied date into the new timezone specific date
            var actualDate = TimeZoneInfo.ConvertTime(dateTime, currentTimeZone, targetTimeZone);
            // Return our converted dateTime
            return actualDate;
        }
    }

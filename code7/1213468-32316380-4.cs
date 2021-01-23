        private DateTime Rtz2ToUtc(DateTime dt)
        {
            if (dt.Kind == DateTimeKind.Utc)
                return dt;
            if (dt.Year < 2011)
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
                return TimeZoneInfo.ConvertTimeToUtc(dt, tz);
            }
            var transition = new DateTime(2014, 10, 26, 2, 0, 0);
            var offset = TimeSpan.FromHours(dt < transition ? 4 : 3);
            return new DateTimeOffset(dt, offset).UtcDateTime;
        }

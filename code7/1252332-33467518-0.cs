        public static long UkTimeStringToUtcMillis(string s)
        {
            string format = "yyyy-MM-dd'T'HH:mm:ss.FFF";
            DateTime dt = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            DateTime utc = TimeZoneInfo.ConvertTimeToUtc(dt, tz);
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long) (utc - epoch).TotalMilliseconds;
        }

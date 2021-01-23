        public static long UkTimeStringToUtcMillis(string s)
        {
            string format = "yyyy-MM-dd'T'HH:mm:ss.FFF";
            DateTime dt = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            TimeSpan offset = tz.GetUtcOffset(dt);
            DateTimeOffset dto = new DateTimeOffset(dt, offset);
            return dto.ToUnixTimeMilliseconds();
        }

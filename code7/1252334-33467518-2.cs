        public static long UkTimeStringToUtcMillis(string s)
        {
            LocalDateTimePattern pattern = LocalDateTimePattern.ExtendedIsoPattern;
            LocalDateTime dt = pattern.Parse(s).Value;
            DateTimeZone tz = DateTimeZoneProviders.Tzdb["Europe/London"];
            Instant i = dt.InZoneLeniently(tz).ToInstant();
            return i.Ticks / NodaConstants.TicksPerMillisecond;
        }

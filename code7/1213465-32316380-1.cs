        private DateTime Rtz2ToUtc(DateTime dt)
        {
            if (dt.Kind == DateTimeKind.Utc)
                return dt;
            DateTimeZone tz = DateTimeZoneProviders.Tzdb["Europe/Moscow"];
            LocalDateTime ldt = LocalDateTime.FromDateTime(dt);
            return ldt.InZoneLeniently(tz).ToDateTimeUtc();
        }

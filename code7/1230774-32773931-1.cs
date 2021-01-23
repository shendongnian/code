    public static class NodaTimeHelpers
    {
        public static Lazy<DateTimeZone> Zone = new Lazy<DateTimeZone>(
            () => DateTimeZoneProviders.Tzdb.GetZoneOrNull("America/Vancouver"));
        public static string ToStringWithOffset(this LocalDateTime localDateTime)
        {
            if (localDateTime == null)
                return "";
            var zonedDateTime = localDateTime.InZoneStrictly(Zone.Value);
            return zonedDateTime.ToString(
                "yyyy-MM-ddTHH:mm:sso<g>",
                System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    public static class DateExtension
    {
        public static string ToStandardString(this DateTime value)
        {
            return value.ToString(
                "yyyy-MM-dd", 
                System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime? ToNullableDateTime(this string val)
        {
            DateTime temp;
            return DateTime.TryParse(val, out temp) ? (DateTime?) temp : null
        }
    }

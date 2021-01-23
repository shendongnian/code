    public static class StringExtensions
    {
        public static string TrimNull(this string value)
        {
            if (value == null) return string.Empty;
            return value.Trim();
        }
    }

    public static class StringExtension
    {
        // Trim strings and compare values without casing
        public static bool SqlCompare(this string source, string value)
        {
            // Handle nulls before trimming
            if (!string.IsNullOrEmpty(source))
                source = source.Trim();
            if (!string.IsNullOrEmpty(value))
                value = value.Trim();
            // Compare strings (case insensitive)
            return string.Equals(source, value, StringComparison.CurrentCultureIgnoreCase);
        }
    }

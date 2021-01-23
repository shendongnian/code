    public static class StringExtension
    {
        public static string SafeToLower(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            return value.ToLower()
        }
    }

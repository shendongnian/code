    public static class StringExtensions
    {
        public static bool HasPlaceholder(this string s)
        {
            return Regex.IsMatch(s, "{\\d+");
        }
    }

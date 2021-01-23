    public static class StringExtension
    {
        public static bool In(this string source, params string[] matches)
        {
            return matches.Contains(source);
        }
    }

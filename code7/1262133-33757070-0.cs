    public static class StringExtensions
    {
        public static bool Contains(this string source, string pattern, StringComparison comparision)
        {
            return source.IndexOf(pattern, comparision) >= 0;
        }
    }

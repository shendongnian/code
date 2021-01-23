    public static class StringExtensions
    {        
        public static bool Contains(this string source, string searchString)
        {
            return source?.IndexOf(subString, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }

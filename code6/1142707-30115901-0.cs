    public static class StringExtensions
    {
        public static bool ContainsOnlyDigits(this string s)
        {
            return s.All(c => c >= '0' && c <= '9');
        }
    }

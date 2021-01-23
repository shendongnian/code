    public static class Extensions
    {
        public static bool HasValue(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }
    }

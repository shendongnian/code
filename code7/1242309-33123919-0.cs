    public static class Extensions
    {
        public static string[] Split(this string s, char separator, StringSplitOptions options)
        {
            return s.Split(new[] { separator }, options);
        }
    //or
        public static string[] Split(this string s, StringSplitOptions options, params char[] separator)
        {
            return s.Split(separator, options);
        }
    }

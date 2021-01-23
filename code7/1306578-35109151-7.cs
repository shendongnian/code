    public static class StringExtensions
    {
        public static string ToSafeSubString(this string value, int count)
        {
             return value != null && value.Length > count ?
                                                       value.Substring(0, count) : value;
        }
    }

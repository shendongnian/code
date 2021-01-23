    public static class StringExtensions
    {
        public static string ValueOrEmpty(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value;
            else
                return "";
    
        }
    }

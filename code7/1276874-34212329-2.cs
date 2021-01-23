    public static class StringHelper
    {
        public static string SafeToLower(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            return value.ToLower();
        }
    }

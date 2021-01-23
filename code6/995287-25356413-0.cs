    public static class DateTimeUtils
    { 
        public static DateTime? TryParse(string value)
        {
            DateTime result;
            if (!DateTime.TryParse(value, out result))
                return null;
            return result;
        }
    }

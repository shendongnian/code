    public static class MyExtensions
    {
        public static DateTime? GetNullableDateTime(
            this String str, string format = "MM/dd/yyyy")
        {
            DateTime tempDate;
            var result = DateTime.TryParseExact(str, format, 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate) 
            ? tempDate 
            : default(DateTime?);
            return result;
        }
    }   

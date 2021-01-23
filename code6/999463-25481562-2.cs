    public static class MyExtensions
    {
        public static DateTime? GetNullableDateTime(this String str, string format = "MM/dd/yyyy")
        {
            DateTime? result;
            DateTime tempDate;
            result = DateTime.TryParseExact(str, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out tempDate) ? tempDate : (DateTime?)null;
            return result;
        }
    }  

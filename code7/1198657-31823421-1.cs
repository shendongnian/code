    public static class Extensions
    {
        public static DateTime ToDateTime(this string dateValue, DateTimeRoutines.DateTimeFormat dateFormat = DateTimeRoutines.DateTimeFormat.USA_DATE)
        {
            DateTime date;
            dateValue.TryParseDateOrTime(dateFormat, out date);
            return date;
        }
    }

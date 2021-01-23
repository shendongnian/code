    public static class DateTimeExtensions
    {
        public static int NumberOfNights(this DateTime date1, DateTime date2)
        {
            //feel free to make here better
            var frm = date1 < date2 ? date1 : date2;
            var to = date1 < date2 ? date2 : date1;
            var totalDays = (int)(to-frm).TotalDays;
            return totalDays > 1 ? totalDays : 1;
        }
    }

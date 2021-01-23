    public class TimePeriod
    {
        public int Id;
        public DateTime FromDate
        {
            get; set;
        }
    
        public DateTime ToDate
        {
            get; set;
        }
    
        public static DateTime Parse(string date)
        {
            var dt = DateTime.Parse(date,
            CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.RoundtripKind);
            return dt;
        }
    }

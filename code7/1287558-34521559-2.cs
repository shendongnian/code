    public class TimeStamp
    {
        public int ID { get; set; }
        public string[] DaysOfWeek { get; set; }
        public string[] HoursOfDay { get; set; }
     public string DaysOfWeekFormatted
        {
            get
            {
                return DaysOfWeek != null ? string.Join("|", DaysOfWeek) : string.Empty;
            }
        }
    }

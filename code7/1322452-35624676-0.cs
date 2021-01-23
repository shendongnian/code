    public class Job
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
    
    public DateTime StartTime
    {
        get
        {
            return new DateTime(Year, Month, Day, StartHours, StartMinutes, 0);
        }
        set
        {
            Day = value.Day;
            Month = value.Month;
            Year = value.Year;
            StartHour = value.Hour;
            StartMinute= value.Minute;
        }
    }
    public DateTime EndTime { get; set; }
    
    }

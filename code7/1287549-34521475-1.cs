    public class TimeStampViewModel
    {
        public int Id { get; set; }
        public string DaysOfWeek { get; set; }
        public string HoursOfDay { get; set; }
        
        public TimeStampViewModel(int id, string[] daysOfWeek, string[] hoursOfDay)
        {
            Id = id;
            DaysOfWeek = string.Join("|", daysOfWeek);
            HoursOfDay = string.Join("|", hoursOfDay);
        }
    }

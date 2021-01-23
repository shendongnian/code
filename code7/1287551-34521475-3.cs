    public class TimeStampViewModel
    {
        public int Id { get; set; }
        public List<OptionalDayOfWeek> DaysOfWeek { get; set; }
        public string HoursOfDay { get; set; }
        
        public TimeStampViewModel(int id, string[] daysOfWeek, string[] hoursOfDay)
        {
            
            Id = id;
            DaysOfWeek = 
                new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" }
                .GroupJoin(daysOfWeek, day => day, dayOfWeek => dayOfWeek, (day, matches) => new OptionalDayOfWeek { DayOfWeek = day, IsAvailable = matches.Any() })
                .ToList();
            HoursOfDay = string.Join("|", hoursOfDay);
        }
    }

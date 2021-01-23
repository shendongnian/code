    class Schedule
    {
        public string Classroom { get; set; }
        public string Weekday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool OverlapsWith(Schedule schedule)
        {
            return schedule.StartTime < EndTime && 
                   schedule.EndTime > StartTime && 
                   schedule.Weekday == Weekday && 
                   schedule.Classroom == Classroom;
        }
    }

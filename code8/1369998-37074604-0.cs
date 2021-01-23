    enum Weekday
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4
    }
    class Schedule
    {
        public string Classroom { get; set; }
        public Weekday Weekday { get; set; }
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

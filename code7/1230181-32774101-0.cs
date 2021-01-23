    public class Week
    {
        public DateTime StartDate { get { return Days.Keys.FirstOrDefault(); } }
        public DateTime EndDate { get { return Days.Keys.LastOrDefault(); } }
        public Dictionary<DateTime, bool> Days { get; private set; }
        public Week(DateTime startDate)
        {
            if (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                throw  new Exception("Week must start on Monday");
            }
            Days = new Dictionary<DateTime, bool>();
            for (int day = 0; day < 7; day++)
            {
                Days.Add(startDate.AddDays(day), false);
            }
        }
        public int Shape
        {
            get { return Days.Where(d => d.Value).Sum(d => (int)Math.Pow(2, (int)d.Key.DayOfWeek)); }
        }
        public bool AreAlike(Week otherWeek)
        {
            return this.Shape == otherWeek.Shape;
        }
        public void SetWorkDays(List<DateTime> workDays)
        {
            foreach (var workDay in workDays)
            {
                Days[Days.Keys.First(d => d.DayOfWeek == workDay.DayOfWeek)] = true;
            }
        }
        public void SetWorkDay(DayOfWeek dayOfWeek, bool work = true)
        {
            Days[Days.Keys.First(d => d.DayOfWeek == dayOfWeek)] = work;
        }
    }

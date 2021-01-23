    class Program
    {
        public static IList<Day> ClearList(IList<Day> days)
        {
            return days.First().IsActive && days.Last().IsActive ?
                ClearList((days.Skip(1).Take(days.Count - 2)).ToList()) :
                days;
        }
        static void Main(string[] args)
        {
            List<Day> days = new List<Day>
            {
                new Day {IsActive = true, Name="M" },
                new Day {IsActive = true, Name="T" },
                new Day {IsActive = false, Name="W" },
                new Day {IsActive = false, Name="Th" },
                new Day {IsActive = true, Name="F" },
                new Day {IsActive = true, Name="St" },
                new Day {IsActive = true, Name="Su" },
            };
            var cleared = ClearList(days);
        }
    }

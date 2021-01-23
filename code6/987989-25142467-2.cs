    static class TimeOrdering
    {
        private static readonly Dictionary<Time, int> timeOrderingMap;
        static TimeOrdering()
        {
            timeOrderingMap = new Dictionary<Time, int>();
            timeOrderingMap[Time.Hourly] = 1;
            timeOrderingMap[Time.Daily] = 2;
            timeOrderingMap[Time.Weekly] = 3;
            timeOrderingMap[Time.Monthly] = 4;
            timeOrderingMap[Time.Annual] = 5;
        }
        public Time DecideMinTime(IEnumerable<Time> g)
        {
            if (g == null) { throw new ArgumentNullException("g"); }
            return g.Min(i => timeOrderingMap[i]);
        }
    }

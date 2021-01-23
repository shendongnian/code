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
            return g.MinBy(i => timeOrderingMap[i]);
        }
        public TSource MinBy<TSource, int>(
            this IEnumerable<TSource> self,
            Func<TSource, int> ordering)
        {
            if (self == null) { throw new ArgumentNullException("self"); }
            if (ordering == null) { throw new ArgumentNullException("ordering"); }
            using (var e = self.GetEnumerator()) {
                if (!e.MoveNext()) {
                    throw new ArgumentException("Sequence is empty.", "self");
                }
                var minElement = e.Current;
                var minOrder = ordering(minElement);
                while (e.MoveNext()) {
                    var curOrder = ordering(e.Current);
                    if (curOrder < minOrder) {
                        minOrder = curOrder;
                        minElement = e.Current;
                    }
                }
                return minElement;
            }
        }
    }

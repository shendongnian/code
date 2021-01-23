    public class TimeComparer : IComparer<Time>
    {
        public int Compare(Time t1, Time t2)
        {
            var periodComparison = t1.Duration.CompareTo(t2.Duration);
            return periodComparison != 0 ? periodComparison : t1.Time.CompareTo(t2.Time);
        }
    }

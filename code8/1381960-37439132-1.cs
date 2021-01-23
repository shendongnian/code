    public class DistinctPerDayComparer : IEqualityComparer<Tuple<int, DateTime>>
    {
        public bool Equals(Tuple<int, DateTime> o1, Tuple<int, DateTime> o2)
        {
            if(o1.Item1 != o2.Item1)
               return false;
            bool isSameDay = o1.Item2.Day == o2.Item2.Day;
            return isSameDay;
        }            
        public int GetHashCode(Tuple<int, DateTime> o)
        {
           return o.Item1.GetHashCode();
        }
    }

    public class DateRange
    {
        public DateRange(DateTime start, DateTime end)
        {
            if (end < start)
               throw new ArgumentException("end");
            Start = start;
            End = end;
        }
    
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public TimeSpan Duration { get { return End - Start; }}
        public override bool Equals(object obj)
        {
            DateRange other = obj as DateRange;
            if (other == null)
               return false;
            return Start == other.Start && End == other.End;
        }
        // override GetHashCode
    }

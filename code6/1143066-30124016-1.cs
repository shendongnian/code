    public class TimeInterval
    {
        public TimeInterval(DateTime start, DateTime end)
        {
            // validation
            Start = start;
            End = end;
        }
    
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public TimeSpan Span { get { return End - Start; }}
        // override Equals and GetHashCode
    }

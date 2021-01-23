    public class JobDateTimeFilterRequest
    {
        public JobFilterRequest JobFilter { get; set; }
    
        public TimeFrame TimeFrame{ get; private set; }
    
        public JobDateTimeFilterRequest(TimeFrame timeFrame)
        {
            this.TimeFrame = timeFrame;
        }
    }

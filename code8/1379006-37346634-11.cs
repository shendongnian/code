    public class StoppedStopwatch
    {
        public RunningStopwatch Start()
        {
            return new RunningStopwatch(...);
        }
    }
    
    public class RunningStopwatch
    {
        public PausedStopwatch Pause()
        {
            return new PausedStopwatch(...);
        }
    
        public TimeSpan Elapsed { get; }
    }
    
    public class PausedStopwatch
    {
        public RunningStopwatch Unpause()
        {
            return new RunningStopwatch(...);
        }
    
        public TimeSpan Elapsed { get; }
    }

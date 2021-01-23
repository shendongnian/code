    public class ProcessApiEventSource : EventSource
    {
        private static ProcessApiEventSource MyLog = new ProcessApiEventSource();
        
        public static ProcessApiEventSource Log  { get { return MyLog; } }
    }

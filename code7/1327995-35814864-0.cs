    public class NewLogger : ILogger
    {
        public bool WriteCore(TraceEventType eventType, int eventId, object state,
            Exception exception, Func<object, Exception, string> formatter)
        {
            if (eventType == TraceEventType.Critical)
            {
                Debug.Fail("We have a critical error " + exception);
            }
            //etc for other eventtypes
            return true;
        }
    }

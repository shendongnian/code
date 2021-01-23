    public class TraceSourceLogTarget : ITraceSourceLogTarget
    {
        private TraceSource _traceSource = new TraceSource();
    
        ...
    
        public void TraceEvent(TraceEventType eventType, int eventId)
        {
            _traceSource.TraceEvent(eventType, eventId);
        }
        
        ...
    }

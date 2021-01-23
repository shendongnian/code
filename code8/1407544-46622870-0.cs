    public class MyTraceListener : TextWriterTraceListener
    {
        public MyTraceListener()
        { }
        public MyTraceListener(string name) : base(name)
        { }
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            base.TraceData(eventCache, "", eventType, id, data);
        }
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
        {
            base.TraceData(eventCache, "", eventType, id, data);
        }
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
        {
            base.TraceEvent(eventCache, "", eventType, id);
        }
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            base.TraceEvent(eventCache, "", eventType, id, message);
        }
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            base.TraceEvent(eventCache, "", eventType, id, format, args);
        }
        public override void Write(string message)
        {
            Writer.Write($"{message} ");
        }
        public override void WriteLine(string message)
        {
            Writer.WriteLine($"{DateTime.UtcNow:s}: {message} ");
        }
    }

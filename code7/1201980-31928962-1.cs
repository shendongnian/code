    public static class TraceSourceExtentions
    {
        [Conditional("DEBUG")]
        public static void TraceDebug(this TraceSource traceSource, string message)
        {
            traceSource.TraceEvent(
                eventType: TraceEventType.Verbose,
                id: 0,
                format: message);
        }
        [Conditional("DEBUG")]
        public static void TraceDebug(this TraceSource traceSource, string format, params object[] args)
        {
            traceSource.TraceEvent(
                eventType: TraceEventType.Verbose,
                id: 0,
                format: format,
                args: args);
        }
    }

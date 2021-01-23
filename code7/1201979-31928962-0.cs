    public static class TraceSourceExtentions
    {
        [Conditional("DEBUG")]
        public static void TraceDebug(this TraceSource traceSource, string message)
        {
            traceSource.TraceInformation(message);
        }
        [Conditional("DEBUG")]
        public static void TraceDebug(this TraceSource traceSource, string format, params object[] args)
        {
            traceSource.TraceInformation(format, args);
        }
    }

    public class UserTraceWriter : ITraceWriter
    {
        public void TraceInfo(string traceText)
        {
            Trace.TraceInformation($"User {HttpContext.Current.User.Identity.Name} {traceText}");
        }
    }

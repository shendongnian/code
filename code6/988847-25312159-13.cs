    public class ExceptionInterceptor : DefaultTraceListener
    {
        public override void WriteLine(object o)
        {
            var exception = o as Exception;
            if (exception != null)
            {
                throw exception;
            }
        }
    }
    // snip... LogException in your CustomErrorLogModule
    protected override void LogException(Exception e, HttpContext context)
    {
        var exceptionListener = new ExceptionInterceptor();
        Trace.Listeners.Add(exceptionListener);
        try
        {
            base.LogException(e, context);
        }
        finally
        {
            Trace.Listeners.Remove(exceptionListener);
        }
    }

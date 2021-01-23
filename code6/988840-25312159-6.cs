    public class ExceptionInterceptor : DefaultTraceListener
    {
        public Exception TracedException { get; set; }
        public override void WriteLine(object o)
        {
            var exception = o as Exception;
            if (exception != null)
            {
                TracedException = exception;
            }
        }
    }

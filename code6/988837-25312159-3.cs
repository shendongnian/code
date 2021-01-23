    protected override void LogException(Exception e, HttpContext context)
    {
        var exceptionListener = new ExceptionInterceptor();
        Trace.Listeners.Add(exceptionListener);
        try
        {
            SomethingWasLogged = false;
            base.LogException(e, context);
            if (!SomethingWasLogged)
            {
                throw exceptionListener.TracedException;
            }
        }
        finally
        {
            Trace.Listeners.Remove(exceptionListener);
        }
    }

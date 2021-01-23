    static void OnException(object sender, UnhandledExceptionEventArgs args)
    {
        try
        {
            Exception ex = (Exception)args.ExceptionObject;
            Logging.LogException(ex);
        }
        catch
        {
           // do nothing to silently swallow error, or try something else...
        }
    }

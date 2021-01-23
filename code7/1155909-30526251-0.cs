    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); // that part was ok
    
    public static void Trace(object message, Exception e)
    {
       Logger.DebugFormat(message, e); // Use InfoFormat or something else if needed
    }

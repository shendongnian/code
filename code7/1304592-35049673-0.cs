    public static class ErrorLog
    {
        public static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
        public static void LogError(System.Exception ex)
        {
            try
            {
                log.Error("ERROR", ex);
            }
            catch (System.Exception)
            {
            }
        }
    }

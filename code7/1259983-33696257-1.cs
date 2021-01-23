    public partial class App
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
    
        public static void Main(string[] args)
        {
            try
            {
                SomeMethod();
            }
            catch (Exception ex)
            {
                logger.ErrorEx(ex, "message");
            }
        }
    
        public static void SomeMethod()
        {
            try
            {
                // Method stuff
            }
            catch (Exception ex)
            {
                logger.ErrorEx(ex, "A handled exception occured.");
                throw;
            }
        }
    }
    
    public static class NLogExt
    {
        public static void ErrorEx(this NLog.Logger logger, Exception ex, string message)
        {
            if (ex.Data["logged"] as bool? == true) return;
            logger.Error(ex, message);
            ex.Data.Add("logged", true);
        }
    }

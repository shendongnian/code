    public static class Utils
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Utils));
    
        public static void NotNull<T>(T obj, string param)
        {
            Log.Debug("Huston, we got a null.");
            if (obj.Equals(null))
                throw new ArgumentNullException(param);
        }
    }

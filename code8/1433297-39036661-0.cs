    public static class NlogExtensions
    {
        public static void Trace(this Logger logger, Func<string> func)
        {
            if (logger.IsTraceEnabled)
            {
                logger.Trace(func());
            }
        }
    }

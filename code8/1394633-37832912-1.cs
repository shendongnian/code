    class MyExpensiveClass
    {
        public void string Serialize()
        {
             return SomethingExpensive;
        }
    }
    class ThisNeedsLogging
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private MyExpensiveClass expensive = new MyExpensiveClass();
        public void TraceSomething()
        {
            if (logger.IsDebugEnabled)
                logger.Debug(expensive.Serialize());
        }
    }

    class MyExpensiveClass {
        public void String Serialize() {
             return SomethingExpensive;
        }
    }
    class ThisNeedsLogging {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private MyExpensiveClass expensive = new MyExpensiveClass();
        void TraceSomething() {
            if (logger.IsDebugEnabled) {
                logger.Debug(expensive.Serialize());
            }
        }
    }

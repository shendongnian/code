    public class SomethingLoggerDecorator<TImplementation> : ISomething
    {
        private readonly ISomething decoratee;
        public SomethingLoggerDecorator(ISomething decoratee)
        {
            this.decoratee = decoratee;
        }
        public void DoSomething()
        {
            var logger = LogManager.GetLogger(typeof(TImplementation));
            logger.Info("Doing Something");
            this.decoratee.DoSomething();
        }
    }

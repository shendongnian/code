    public class SomethingLoggerDecorator : ISomething
    {
        private readonly ISomething decoratee;
        private readonly DecoratorContext context;
        public SomethingLoggerDecorator(ISomething decoratee, DecoratorContext context)
        {
            this.decoratee = decoratee;
            this.context = context;
        }
        public void DoSomething()
        {
            var logger = LogManager.GetLogger(this.context.ImplementationType.GetType());
            logger.Info("Doing Something");
            this.decoratee.DoSomething();
        }
    }

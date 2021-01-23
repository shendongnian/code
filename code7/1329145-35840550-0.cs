    static class LoggerFactory
    {
        [Export("GetLogger")]
        public ILogger GetLogger(Type type)
        {
            return new SimpleLogger(type);
        }
    }
    class ExampleObject
    {
        private readonly ILogger logger;
        [ImportingConstructor]
        public ExampleObject([Import(ContractName = "GetLogger", AllowDefault = true)]Func<Type, ILogger> loggerCreator)
        {
            logger = loggerCreator?.Invoke(this.GetType());
        }
    }

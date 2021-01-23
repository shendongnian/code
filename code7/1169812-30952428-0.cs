    public class ConsoleTargetBuilderClient
    {
        private ITargetBuilder _builder;
    
        public ConsoleTargetBuilderClient(ITargetBuilder builder)
        {
            _builder = builder;
        }
    
        public void DoSomething()
        {
            _builder.AddNLogConfigurationTypeTagret();
        }
    }

    public class RunnersProvider : Provider<IReadOnlyCollection<Runner>>
    {
        private readonly IList<IConfig> runnerConfigurations;
        private readonly IRunnerFactory runnerFactory;
        public RunnersProvider(IList<IConfig> runnerConfigurations, IRunnerFactory runnerFactory)
        {
            this.runnerConfigurations = runnerConfigurations;
            this.runnerFactory = runnerFactory;
        }
        protected override IReadOnlyCollection<Runner> CreateInstance(IContext context)
        {
            return this.runnerConfigurations
                .Select(this.runnerFactory.Create)
                .ToArray();
        }
    }
   
    kernel.Bind<IReadOnlyCollection<Runner>>().ToProvider<RunnersProvider>();

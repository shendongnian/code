    public interface IRunnerFactory
    {
        // all parameters are passed to the constructor of Runner
        // parameters are matched by name, so make sure they match! ctor(IConfig myconfig) won't work, it must be ctor(IConfig config).
        // but of course you can add more parameters to the ctor and have them injected: ctor(IService1 foo, IControl bar, IConfig config, IService2 foo2)
        Runner Create(IConfig config);
    }
    public class AllRunner
    {
        private readonly IList<IConfig> runnerConfigurations;
        private readonly IRunnerFactory runnerFactory;
        public AllRunner(IList<IConfig> runnerConfigurations, IRunnerFactory runnerFactory)
        {
            this.runnerConfigurations = runnerConfigurations;
            this.runnerFactory = runnerFactory;
        }
        public void RunAll()
        {
            Task[] runners = this.runnerConfigurations
                .Select(this.runnerFactory.Create)
                .Select(runner => Task.Run((Action) runner.Run))
                .ToArray();
            Task.WaitAll(runners);
        }
    }
    // you could also use .InNamedScope() or maybe InParentScope() or InCallScope() -- see the NamedScope extension!
    kernel.Bind<IControl>().To<Control>().InSingletonScope();
    // implementation is auto generated.
    kernel.Bind<IRunnerFactory>().ToFactory();
    kernel.Bind<IConfig>().To<Config1>();
    kernel.Bind<IConfig>().To<Config2>();
    kernel.Bind<IConfig>().To<Config3>();

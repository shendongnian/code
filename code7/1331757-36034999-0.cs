    public class Program
    {
        private static ILifetimeScope _scope;
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        public static void Main(string[] args)
        {
            try
            {
                XmlConfigurator.Configure();
                // configure composition
                _scope = CompositionRoot.CreateScope();
                HostFactory.Run(x =>
                {
                    x.UseLog4Net();
                    x.UseAutofacContainer(_scope);
                    x.Service<IMyService>(svc =>
                    {
                        svc.ConstructUsingAutofacContainer();
                        svc.WhenStarted(tc => tc.Start());
                        svc.WhenStopped(tc =>
                        {
                            tc.Stop();
                            _scope.Dispose();
                        });
                    });
                    x.RunAsNetworkService();
                    x.StartManually();
                });
            }
            catch (Exception e)
            {
                Log.Error("An error occurred during service construction.", e);
                throw;
            }
        }
    }

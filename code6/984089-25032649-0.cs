    public class Consumer
    {
        IDataService dataService = null;
        public Consumer(string runtimeChoice)
        {
            DependencyOverride<IDatabase> dependency = null;
            if (runtimeChoice == "SQLSERVER")
            {
                dependency = new DependencyOverride<IDatabase>
                                     (Container.Resolve<IDatabase>("SQLDatabase"));
            }
            else if (runtimeChoice == "Oracle")
            {
                dependency = new DependencyOverride<IDatabase>
                                     (Container.Resolve<IDatabase>("OracleDatabase"));
            }            
            dataService = _container.Resolve<IDataService>(dependency);
        }
    }

    public class DatabaseRepositoryFactory
    {
        private IHostingEnvironment _env { get; set; }
        public Func<IServiceProvider, IDatabaseRepository> DatabaseRepository { get; private set; }
        public DatabaseRepositoryFactory(IHostingEnvironment env)
        {
            _env = env;
            DatabaseRepository = GetDatabaseRepository;
        }
        private IDatabaseRepository GetDatabaseRepository(IServiceProvider serviceProvider)
        {
            var contextSettings = serviceProvider.GetService<IContextSettings>();
            var currentCustomer = contextSettings.GetCurrentCustomer();
            if(SOME CHECK)
            {
                var currentDatabase = currentCustomer.CurrentDatabase as FileSystemDatabase;
                var databaseRepository = new FileSystemDatabaseRepository(currentDatabase.Path);
                return databaseRepository;
            }
            else
            {
                var currentDatabase = currentCustomer.CurrentDatabase as EntityDatabase;
                var dbContext = new CustomDbContext(currentDatabase.ConnectionString, _env.EnvironmentName);
                var databaseRepository = new EntityFrameworkDatabaseRepository(dbContext);
                return databaseRepository;
            }
        }
    }

    public interface IDatabaseSettings 
    {
         string Host { get; set; }
    }
    public class RegistryDatabaseSettings : IDatabaseSettings
    {
         // This property should get and set the setting from and
         // against the Windows Registry. It's just a sample and dummy
         // implementation
         public string Host { get; set; }
    }
    
    public interface ISomeRepository
    {
    }
    
    public class SomeRepositoryImpl : ISomeRepository
    {
        private readonly IDatabaseSettings _dbSettings;
        
        // Inject IDatabaseSetttings as constructor's dependency
        public SomeRepositoryImpl(IDatabaseSettings dbSettings)
        {
             _dbSettings = dbSettings;
        }
    
        public IDatabaseSettings DatabaseSettings => _dbSettings;
    }

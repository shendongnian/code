    public class DatabaseSettings
    {
         public string Host { get; set; }
    }
    
    public interface ISomeRepository
    {
    }
    
    public class SomeRepositoryImpl : ISomeRepository
    {
        private readonly DatabaseSettings _dbSettings;
        
        // Inject DatabaseSetttings as constructor's dependency
        public SomeRepositoryImpl(DatabaseSettings dbSettings)
        {
             _dbSettings = dbSettings;
        }
    
        public DatabaseSettings DatabaseSettings => _dbSettings;
    }

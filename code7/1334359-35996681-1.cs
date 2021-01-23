    public class DatabaseSettings
    {
         public string Host { get; set; }
    }
    public class Settings 
    { 
         public DatabaseSettings Database { get; } = new DatabaseSettings();
    }
    public interface ISomeRepository
    {
    }
    
    public class SomeRepositoryImpl : ISomeRepository
    {
        private readonly Settings _settings;
        
        // Inject Settings as constructor's dependency
        public SomeRepositoryImpl(Settings settings)
        {
             _settings = settings;
             // Now you can access DatabaseSettings as follows:
             // Settings.Database.Host
        }
    
        public Settings Settings => _settings;
    }

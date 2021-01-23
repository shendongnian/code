    // Very simple singleton using an static field initializer
    public class SimpleSingleton
    {
         private readonly static SimpleSingleton _instance = new SimpleSingleton();
    
         public SimpleSingleton Instance => _instance;
    }

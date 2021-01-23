    // Very simple singleton using a static field initializer
    public class SimpleSingleton
    {
         private readonly static SimpleSingleton _instance = new SimpleSingleton();
    
         public SimpleSingleton Instance => _instance;
    }

    public sealed class Singleton : ISingleton
    {
        public static Singleton Instance { get; } = new Singleton();
        
        static Singleton() { }
        private Singleton() { }
    
        // methods
    }

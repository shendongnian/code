    public class Singleton
    {
        private static Lazy<Singleton> instance = new Lazy<Singleton>();
        public static Singleton Instance => instance.Value;
    }

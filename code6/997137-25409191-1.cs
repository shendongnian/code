    public class Singleton
    {
        private static Singleton instance = new Singleton();
        public static Singleton getInstance { get { return instance; } }
    }

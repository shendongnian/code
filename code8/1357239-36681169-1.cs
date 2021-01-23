    public class Singleton
    {
        public static Singleton Instance { get; }
            = (DateTime.Now.Seconds & 1) == 0
              ? (Singleton) new EvenSingleton() : new OddSingleton();
        private Singleton() {}
        private class OddSingleton : Singleton {}
        private class EvenSingleton : Singleton {}
    }

    public sealed class Singleton
    {
        private static readonly Singleton <Instance>k__BackingField = new Singleton();
        public static Singleton Instance { get { return <Instance>k__BackingField; } }
        private Singleton() { /* some initialization code */ }
    }

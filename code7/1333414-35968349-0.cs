    public sealed class SingletonDemo
    {
        public static SingletonDemo Instance { get; } = new SingletonDemo();    
        private SingletonDemo() {}
    }

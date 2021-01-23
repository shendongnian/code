    internal static class Lifecycle
    {
        private static readonly object LockObject;
        private static Engine Engine;
        static Lifecycle()
        {
            LockObject = new object();
            Engine = new Engine();
        }
        public static void Start()
        {
            Monitor.Enter(LockObject);
            Engine.Start();
            Thread.Sleep(800);
        }
        public static void Stop()
        {
            Engine.Stop();
            Monitor.Exit(LockObject);
        }
    }

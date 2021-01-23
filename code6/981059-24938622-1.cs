    internal static class Lifecycle
    {
        private static Engine Engine;
        static Lifecycle()
        {
            Engine = new Engine();
        }
        public static void Start()
        {
            Monitor.Enter(Engine);
            Engine.Start();
            Thread.Sleep(800);
        }
        public static void Stop()
        {
            Engine.Stop();
            Monitor.Exit(Engine);
        }
    }

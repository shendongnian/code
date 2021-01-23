    class Program
    {
        private static List<Delegate> handlers = new List<Delegate>();
        public static void RegisterHandler<T>(Action<T> del)
        {
            handlers.Add(del);
        }
        public static void InvokeHandlers(params object[] args)
        {
            foreach (var h in handlers)
            {
                h.Method.Invoke(h.Target, args);
            }
        }
        static void Main(string[] args)
        {
            RegisterHandler((object a) => Console.WriteLine("#1:" + a));
            RegisterHandler((object a) => Console.WriteLine("#2:" + a));
            InvokeHandlers("foo");
            InvokeHandlers(1234);
        }
    }

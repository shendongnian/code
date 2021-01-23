    class Test {
        [ThreadStatic]
        static int range=10;
        public static void Run() {
            Action action = () => {
                Console.WriteLine("Thread = {0}, Value = {1}", Thread.CurrentThread.ManagedThreadId, range);
            };
            Console.WriteLine("Start thread = {0}, Value = {1}", Thread.CurrentThread.ManagedThreadId, range);
            Parallel.Invoke(action, action);
        }
    }

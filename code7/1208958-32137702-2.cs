    static void Main(string[] args)
        {
            Console.WriteLine("Id main thread is: {0}", Thread.CurrentThread.ManagedThreadId);
            TestAsyncAwaitMethods();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
        public async static void TestAsyncAwaitMethods()
        {
            Console.WriteLine("Id thread (void - 0) is: {0}", Thread.CurrentThread.ManagedThreadId);
            var _value = await LongRunningMethod();
            Console.WriteLine("Id thread (void - 1) is: {0}", Thread.CurrentThread.ManagedThreadId);
        }
        public static async Task<int> LongRunningMethod()
        {
            Console.WriteLine("Id thread (int) is: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Starting Long Running method...");
            await Task.Delay(1000);
            Console.WriteLine("End Long Running method...");
            return 1;
        }

        public static CancellationToken Token { get; private set; }
        public static void Cancel()
        { 
            Token = new CancellationToken(true);
        }
        async static Task DoSomething(int interval)
        {
            while (true)
            {
                Console.WriteLine("1");
                await Task.Delay(interval, Token);
            }
        }
        private static void Main(string[] args)
        {
            DoSomething(1000);
            Thread.Sleep(5000);
            Cancel();
            Console.ReadLine();
        }

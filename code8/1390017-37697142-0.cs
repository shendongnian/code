    static class Program
    {
        private static bool _executeFirstMethod = true;
        static void Main(string[] args)
        {
            using (Timer timer = new Timer(5000))  // 5 seconds instead of 5 minutes (for testing)
            {
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
                Console.WriteLine("Timer is started");
                Console.ReadLine();
            }
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_executeFirstMethod)
                Method1();
            else
                Method2();
            _executeFirstMethod = !_executeFirstMethod;
        }
        private static void Method1()
        {
            Console.WriteLine("Method1 is executed at {0}", DateTime.Now);
        }
        private static void Method2()
        {
            Console.WriteLine("Method2 is executed at {0}", DateTime.Now);
        }
    }

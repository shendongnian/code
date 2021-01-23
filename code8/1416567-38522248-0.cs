     static void DoSomething(object n)
        {
            Console.WriteLine(n);
            Thread.Sleep(10);
        }
        static void Main(string[] args)
        {
            ThreadPool.SetMaxThreads(20, 10);
            for (int x = 0; x < 30; x++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomething), x);
            }
            Console.Read();
        }

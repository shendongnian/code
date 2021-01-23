        static ManualResetEvent eve = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            var threads = new List<Thread>();
            for (int i = 0; i < 10; ++i)
            {
                int iCopy = i;
                var t = new Thread(() => thread(iCopy));
                threads.Add(t);
                t.Start();
            }
            Console.WriteLine("Pausing");
            Thread.Sleep(5000);
            eve.Set();
            foreach (var t in threads) t.Join();
            Console.WriteLine("All done");
            Console.ReadKey();
        }
        static void thread(int n)
        {
            eve.WaitOne();
            Console.WriteLine("Thread {0}", n);
        }

    class Program
    {
        private readonly object syncLock = new object();
        private int num = 0;
        private static int currentIndex = 0;
        private static void Main(string[] args)
        {
            Program p = new Program();
            p.num = 11;
            // just return the threads, so we can join
            var threadList = p.callThreadCreation();
    
            // don't need Thread.Sleep() here
            //while (p.num > 0)
            //{
            //    Thread.Sleep(1000);
            //}
            foreach (var t in threadList) { t.Join(); }
            Console.WriteLine("All done {0}", currentIndex);
            Console.Read();
        }
        public IReadOnlyList<Thread> callThreadCreation()
        {
            var threadList = new List<Thread>();
            for (int i = 1; i <= 4; i++)
            {
                // this is easier to read for me
                var T = new Thread(startProcessing)
                {
                    Name = "T" + i
                };
                // just return the threads, so we can join
                threadList.Add(T);
                T.Start();
            }
            // just return the threads, so we can join
            return threadList;
        }
        private void startProcessing()
        {
            while (true)
            {
                int tempIndex;
                lock (syncLock)
                {
                    // I'm not sure what the point of this line is... sometimes "tempIndex" will
                    // be the same between two threads, but this just seems like a progress report
                    // for the person watching the program so I didn't fix this.
                    tempIndex = currentIndex;
                    num--;
                    if (num < 0) break;
                }
    
                print(tempIndex);
                Interlocked.Increment(ref currentIndex);
                Thread.Sleep(1000);
            }
        }
    
        private void print(int x)
        {
            Console.WriteLine(x);
        }
    }

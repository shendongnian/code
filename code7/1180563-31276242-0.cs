    class Program
    {
        private static object syncLock = new object();
        int num = 0;
        // make static so we can read in Main()
        static int currentIndex = 0;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.num = 11;
            p.callThreadCreation();
    
            while (p.num > 0)
            {
                Thread.Sleep(1000);
            }
    
            Console.WriteLine("All done {0}", currentIndex);
            Console.Read();
        }
        public void callThreadCreation()
        {
            for (int i = 1; i <= 4; i++)
            {
                string name = "T" + i;
                Thread T = new Thread(new ThreadStart(() => startProcessing()));
                T.Name = name;
                T.Start();
            }
        }
        private void startProcessing()
        {
            while (num > 0)
            {
                int tempIndex;
                lock (syncLock)
                {
                    tempIndex = currentIndex;
                }
                // putting this in front of the increment/decrement operations makes the race condition more likely
                print(tempIndex);
                Interlocked.Decrement(ref num);
                Interlocked.Increment(ref currentIndex);
                Thread.Sleep(1000);
            }
        }
    
        private void print(int x)
        {
            Console.WriteLine(x);
        }
    }

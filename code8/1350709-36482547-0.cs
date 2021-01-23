    class Program
        {
            static ConcurrentQueue<candle> sourceCandleList = new ConcurrentQueue<candle>();
            static ConcurrentBag<param> paramList = new ConcurrentBag<param>();
            static void Main(string[] args)
            {
                var threads = new List<Thread>();
                var numberOfThreads = 10;
                for (int i = 0; i < numberOfThreads; i++)
                {
                    threads.Add(new Thread(Run));
                }
                threads.ForEach(i => i.Start());
            }
            static void Run()
            {
                candle item;
                while (sourceCandleList.TryDequeue(out item))
                {
                    //do you processing here
                }
            }
        }

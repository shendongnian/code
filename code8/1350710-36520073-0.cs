    static void Main(string[] args)
        {
            // Parameters to test
            List<candle> paramList = new List<candle>();
            // Original list
            List<candle> sourceList = new List<candle>();
            // Create a copy for each thread
            int maxThreads = 16;
            ConcurrentBag<int> pool = new ConcurrentBag<int>();
            List<candle>[] processList = new List<candle>[maxThreads];
            for (int i = 0; i <= maxThreads - 1; i++)
            {
                pool.Add(i);
                processList[i] = sourceList.ConvertAll(p => p);
            }
            Parallel.For(0, paramList.Count,
            new ParallelOptions { MaxDegreeOfParallelism = maxThreads },
            p =>
            {
                int slot = 0;
                int item;
                for (int i = 0; i <= 2; i++)
                {
                    if (pool.TryTake(out item))
                    {
                        slot = item;
                        break;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                lock (processList[slot])
                {
                    // Do processing here
                }
                pool.Add(slot);
            });
        }

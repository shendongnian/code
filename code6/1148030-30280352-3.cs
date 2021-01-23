    public class InterlockedInt
    {
        private int cnt;
        public int Cnt
        {
            get
            {
                return cnt;
            }
        }
        public void Increment()
        {
            Interlocked.Increment(ref cnt);
        }
    }
    public static IDictionary<string, InterlockedInt> Parse(string path, int numThreads)
    {
        //var wordCount = new Dictionary<string, int>();
        var wordCount = new ConcurrentDictionary<string, InterlockedInt>();
        var coll = new BlockingCollection<string>();
        ThreadStart thread = () =>
        {
            Func<string, InterlockedInt> del = x => new InterlockedInt();
            string line;
            while (coll.TryTake(out line, -1))
            {
                var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    wordCount.GetOrAdd(word, del).Increment();
                }
            }
        };
        Thread[] threads = new Thread[numThreads];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(thread);
            threads[i].Start();
        }
        using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
        using (var streamReader = new StreamReader(fileStream))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                coll.Add(line);
            }
            coll.CompleteAdding();
        }
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }
        return wordCount;
    }

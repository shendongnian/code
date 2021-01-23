    class Program
    {
        static long _total;
        static ConcurrentQueue<int> _queued;
     
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 1000000);
            _queued = new ConcurrentQueue<int>(numbers);
            _total = 0;
     
            Task task1 = Task.Run(() => ProcessQueue());
            Task task2 = Task.Run(() => ProcessQueue());
     
            Task.WaitAll(
                Task.Run(() => ProcessQueue()), 
                Task.Run(() => ProcessQueue()));
     
            Console.WriteLine("Total: {0}", _total);
        }
     
        static void ProcessQueue()
        {
            int value;
     
            while (_queued.TryDequeue(out value))
            {
                Interlocked.Add(ref _total, value);
            }
        }
    }

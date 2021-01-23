    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110,120,130,140,150 };
            Example e = new Example();
            e.AddRange(ints);
            e.Start();
            int k = 0;
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                e.Add(input);
            }
        }
    }
    class Example
    {
        private readonly ManualResetEventSlim _hasNewData;
        private readonly ConcurrentStack<int> _queue;
        private readonly CancellationTokenSource _stopConsumers;
        private readonly ManualResetEvent _waitForStopping;
        private Task _printTask;
        public Example()
        {
            _hasNewData = new ManualResetEventSlim(false);
            _queue = new ConcurrentStack<int>();
            _stopConsumers = new CancellationTokenSource();
            _waitForStopping = new ManualResetEvent(false);
        }
        public void Start()
        {
            _printTask = Task.Factory.StartNew(() => PrintMethod());
        }
        public void AddRange(int[] ints)
        {
            _hasNewData.Set();
            _queue.PushRange(ints);
        }
        public void Add(int v)
        {
            _hasNewData.Set();
            _queue.Push(v);
        }
        public void Stop()
        {
            _stopConsumers.Cancel();
            _waitForStopping.WaitOne();
        }
        private void PrintMethod()
        {
            while (!_stopConsumers.IsCancellationRequested)
            {
                _hasNewData.Wait();
                int v;
                while (_queue.TryPop(out v))
                {
                    Console.WriteLine("Dequed: {0}", v);
                    Thread.Sleep(500);
                }
            }
            _waitForStopping.Set();
        }
    }

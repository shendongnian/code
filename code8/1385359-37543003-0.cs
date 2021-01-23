    class Example
    {
        private readonly ManualResetEventSlim _hasNewData;
        private readonly ConcurrentQueue<int> _queue;
        private readonly CancellationTokenSource _stopConsumers;
        private readonly ManualResetEvent _waitForStopping;
        private Task _printTask;
    
        public Example()
        {
            _hasNewData = new ManualResetEventSlim(false);
            _queue = new ConcurrentQueue<int>();
            _stopConsumers = new CancellationTokenSource();
            _waitForStopping = new ManualResetEvent(false);
        }
        public void Start()
        {
            _printTask = Task.Factory.StartNew(() => PrintMethod());
        }
        public void Add(int v)
        {
            _hasNewData.Set();
            _queue.Enqueue(v);
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
                while(_queue.TryDequeue(out v))
                {
                    Console.WriteLine("Dequed: {0}", v);
                }
            }
            _waitForStopping.Set();
        }
    }

    public class Producer : IDisposable
    {
        private CancellationTokenSource _Cts;
        private Random _Random = new Random();
        private int _WorkCounter = 0;
        private BlockingCollection<Task<String>> _Workers;
        private Task _WorkProducer;
        public Producer()
        {
            _Workers = new BlockingCollection<Task<String>>();
        }
        public IEnumerable<Task<String>> Workers
        {
            get { return _Workers.GetConsumingEnumerable(); }
        }
        public void Dispose()
        {
            Stop();
        }
        public void Start()
        {
            if (_Cts != null)
                throw new InvalidOperationException("Producer has already been started.");
            _Cts = new CancellationTokenSource();
            _WorkProducer = Task.Factory.StartNew(() => Run(_Cts.Token));
        }
        public void Stop()
        {
            var cts = _Cts;
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
                _Cts = null;
            }
            _WorkProducer.Wait();
        }
        private String GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new String(Enumerable
                .Repeat(chars, 8)
                .Select(s => s[_Random.Next(s.Length)])
                .ToArray());
            return result;
        }
        private void Run(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var worker = StartNewWorker();
                _Workers.Add(worker);
                Task.Delay(100);
            }
            _Workers.CompleteAdding();
            _Workers = new BlockingCollection<Task<String>>();
        }
        private Task<String> StartNewWorker()
        {
            return Task.Factory.StartNew<String>(Worker);
        }
        private String Worker()
        {
            var workerId = Interlocked.Increment(ref _WorkCounter);
            var neededTime = TimeSpan.FromSeconds(_Random.NextDouble() * 5);
            Console.WriteLine("Worker " + workerId + " starts in " + neededTime);
            Task.Delay(neededTime).Wait();
            var result = GetRandomString();
            Console.WriteLine("Worker " + workerId + " finished with " + result);
            return result;
        }
    }

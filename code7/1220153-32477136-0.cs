    internal class Producer : IDisposable {
        private readonly BlockingCollection<RandomStringRequest> _collection;
        public Producer() {
            _collection = new BlockingCollection<RandomStringRequest>(new ConcurrentQueue<RandomStringRequest>());
        }
        public void Start() {
            Task consumer = Task.Factory.StartNew(() => {
                try {
                    foreach (var request in _collection.GetConsumingEnumerable()) {
                        Thread.Sleep(100); // long work
                        request.SetResult(GetRandomString());
                    }
                }
                catch (InvalidOperationException) {
                    Console.WriteLine("Adding was compeleted!");
                }
            });
        }
        public RandomStringRequest GetRandomString(string consumerName) {
            var request = new RandomStringRequest();
            _collection.Add(request);
            return request;            
        }
        public void Dispose() {
            _collection.CompleteAdding();
        }
        private string GetRandomString() {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(Enumerable
                .Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
            return result;
        }
    }
    internal class RandomStringRequest : IDisposable {
        private string _result;
        private ManualResetEvent _signal;
        public RandomStringRequest() {
            _signal = new ManualResetEvent(false);
        }
        public void SetResult(string result) {
            _result = result;
            _signal.Set();
        }
        public string GetResult() {
            _signal.WaitOne();
            return _result;
        }
        public bool TryGetResult(TimeSpan timeout, out string result) {
            result = null;
            if (_signal.WaitOne(timeout)) {
                result = _result;
                return true;
            }
            return false;
        }
        public void Dispose() {
            _signal.Dispose();
        }
    }
    internal class Consumer {
        private Producer _producer;
        private string _name;
        public Consumer(
            Producer producer,
            string name) {
            _producer = producer;
            _name = name;
        }
        public string GetOrderedString() {
            using (var request = _producer.GetRandomString(_name)) {
                // wait here for result to be prepared
                var produced = request.GetResult();
                return String.Join(String.Empty, produced.OrderBy(c => c));
            }
        }
    }

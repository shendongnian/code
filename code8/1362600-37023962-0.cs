    public class LogQueue : IDisposable {
        private static readonly Lazy<LogQueue> _isntance = new Lazy<LogQueue>(CreateInstance, true);
        private Thread _thread;
        private readonly BlockingCollection<LogItem> _queue = new BlockingCollection<LogItem>(new ConcurrentQueue<LogItem>());
        private static LogQueue CreateInstance() {
            var queue = new LogQueue();
            queue.Start();
            return queue;
        }
        public static LogQueue Instance => _isntance.Value;
        public void QueueItem(LogItem item) {
            _queue.Add(item);
        }
        public void Dispose() {
            _queue.CompleteAdding();
            // wait here until all pending messages are written
            _thread.Join();
        }
        private void Start() {
            _thread = new Thread(ConsumeQueue) {
                IsBackground = true
            };
            _thread.Start();
        }
        private void ConsumeQueue() {
            foreach (var item in _queue.GetConsumingEnumerable()) {
                try {
                    // append to your item.TargetFile here                    
                }
                catch (Exception ex) {
                    // do something or ignore
                }
            }
        }
    }
    public class LogItem {
        public string TargetFile { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }

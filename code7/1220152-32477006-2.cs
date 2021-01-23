    public class Consumer
    {
        private Task _Consumer;
        private IEnumerable<Task<String>> _Workers;
        public Consumer(IEnumerable<Task<String>> workers)
        {
            if (workers == null)
                throw new ArgumentNullException("workers");
            _Workers = workers;
        }
        public void Start()
        {
            var consumer = _Consumer;
            if (consumer == null
                || consumer.IsCompleted)
            {
                _Consumer = Task.Factory.StartNew(Run);
            }
        }
        private void Run()
        {
            foreach (var worker in _Workers)
            {
                var result = worker.Result;
                Console.WriteLine("Received result " + result);
            }
        }
    }

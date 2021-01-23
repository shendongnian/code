    class Engine
    {
        private int _counter;
        public void Start()
        {
            Interlocked.Increment(ref _counter);
            Console.WriteLine("Engine was started");
        }
        public void Stop()
        {
            Interlocked.Decrement(ref _counter);
            if (_counter == 0)
            {
                Console.WriteLine("Engine was stopped");
            }
        }
    }

    static void Main(string[] args)
    {
        using (var testClass = new TestClass())
        {
                
        }
        Console.ReadKey();
    }
    class TestClass : IDisposable
    {
        private Task _task;
        private CancellationTokenSource _cancellationTokenSource;
        public TestClass()
        {
            Console.WriteLine("TestClass Created.");
            _cancellationTokenSource = new CancellationTokenSource();
            _task = Task.Factory.StartNew(TestDoWork);
        }
        public void TestDoWork()
        {
            while (true)
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    break;
                }
            }
            Console.WriteLine("Task Ended.");
        }
        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                // Cancel the Task
                if (_cancellationTokenSource == null) return;
                _cancellationTokenSource.Cancel();
                _task.Wait();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
                _task = null;
                Console.WriteLine("TestClass Dispose.");
            }
            // free native resources here if there are any
        }
    }

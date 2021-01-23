    class LockingWithResetEvents
    {
        private readonly ManualResetEvent _resetEvent = new ManualResetEvent(false);
        public void Test()
        {
            MethodUsingResetEvents();
        }
        private void MethodUsingResetEvents()
        {
            ThreadPool.QueueUserWorkItem(_ => DoSomethingLong());
            ThreadPool.QueueUserWorkItem(_ => ShowMessageBox());
        }
        private void DoSomethingLong()
        {
            Console.WriteLine("Doing somthing.");
            Thread.Sleep(1000);
            _resetEvent.Set();
        }
        private void ShowMessageBox()
        {
            _resetEvent.WaitOne();
            Console.WriteLine("Hello world.");
        }
    }

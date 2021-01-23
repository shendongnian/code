    public class MultiThreadedExample : IDisposable
    {
        private Thread _thread;
        private ManualResetEvent _terminatingEvent = new ManualResetEvent(false);
        private ManualResetEvent _runningEvent = new ManualResetEvent(false);
        private ManualResetEvent _threadStartedEvent = new ManualResetEvent(false);
        public MultiThreadedExample()
        {
            _thread = new Thread(MyThreadMethod);
            _thread.Start();
            _threadStartedEvent.WaitOne();
        }
        private void MyThreadMethod()
        {
            _threadStartedEvent.Set();
            var events = new WaitHandle[] { _terminatingEvent, _runningEvent };
            while (WaitHandle.WaitAny(events) != 0)  // <- WaitAny returns index within the array of the event that was Set.
            {
                try
                {
                    // do work......
                }
                finally
                {
                    // reset the event. so it can be triggered again.
                    _runningEvent.Reset();
                }
                
            }
        }
        public bool TryStartWork()
        {
            // is it already running?
            if (!_runningEvent.WaitOne(0))
            {
                // it's not running atm
                _runningEvent.Set();
                return true;
            }
            return false;
        }
        public void Dispose()
        {
            // break the whileloop
            _terminatingEvent.Set();
            // wait for the thread to terminate.
            _thread.Join();
        }
    }

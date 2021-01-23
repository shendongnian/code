    public sealed class EventSignaller
    {
        public void Signal()
        {
            lock (_lock)
            {
                Monitor.PulseAll(_lock);
            }
        }
        public void Wait()
        {
            lock (_lock)
            {
                Monitor.Wait(_lock);
            }
        }
        public bool Wait(int timeoutMilliseconds)
        {
            lock (_lock)
            {
                return Monitor.Wait(_lock, timeoutMilliseconds);
            }
        }
        readonly object _lock = new object();
    }

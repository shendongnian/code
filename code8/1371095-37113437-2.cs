    public class MutexFactory
    {
        private string _name;
        public MutexFactory(string name)
        {
            _name = name;
        }
        public SingleUseMutex Lock()
        {
            return new SingleUseMutex(_name);
        }
    }
    public class SingleUseMutex : IDisposable
    {
        private readonly Mutex _mutex;
        internal SingleUseMutex(string name)
        {
            _mutex = new Mutex(false, name);
            _mutex.WaitOne();
        }
        public void Dispose()
        {
            _mutex.ReleaseMutex();
            _mutex.Dispose();
        }
    }

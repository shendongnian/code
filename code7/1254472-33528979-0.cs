    public class NamedLock : IDisposable
    {
        public NamedLock(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            mutex = new Mutex(false, name);
            mutex.WaitOne();
        }
        public void Dispose()
        {
            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex = null;
            }
        }
        private Mutex mutex;
    }

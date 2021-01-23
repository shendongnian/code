    public class ThrottlingHelper : IDisposable
    {
        //Holds time stamps for all started requests
        private readonly List<long> _requestsTx;
        private readonly ReaderWriterLockSlim _lock;
        private readonly int _maxLimit;
        private TimeSpan _interval;
        public ThrottlingHelper(int maxLimit, TimeSpan interval)
        {
            _requestsTx = new List<long>();
            _maxLimit = maxLimit;
            _interval = interval;
            _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        }
        public bool RequestAllowed
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    var nowTx = DateTime.Now.Ticks;
                    return _requestsTx.Count(tx => nowTx - tx < _interval.Ticks) < _maxLimit;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }
        public void StartRequest()
        {
            _lock.EnterWriteLock();
            try
            {
                _requestsTx.Add(DateTime.Now.Ticks);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
        public void EndRequest()
        {
            _lock.EnterWriteLock();
            try
            {
                var nowTx = DateTime.Now.Ticks;
                _requestsTx.RemoveAll(tx => nowTx - tx >= _interval.Ticks);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
        public void Dispose()
        {
            _lock.Dispose();
        }
    }

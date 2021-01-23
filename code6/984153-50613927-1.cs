    public class ThrottlingHelper : DisposeBase
    {
        //Holds time stamps for all started requests
        private readonly List<long> _requestsTx;
        private readonly Mutex _mutex = new Mutex();
        private readonly int _maxLimit;
        private readonly TimeSpan _interval;
        public ThrottlingHelper(int maxLimit, TimeSpan interval)
        {
            _requestsTx = new List<long>();
            _maxLimit = maxLimit;
            _interval = interval;
        }
        public bool StartRequestIfAllowed
        {
            get
            {
                _mutex.WaitOne();
                try
                {
                    var nowTx = DateTime.Now.Ticks;
                    if (_requestsTx.Count(tx => nowTx - tx < _interval.Ticks) < _maxLimit)
                    {
                        _requestsTx.Add(DateTime.Now.Ticks);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    _mutex.ReleaseMutex();
                }
            }
        }
        public void EndRequest()
        {
            _mutex.WaitOne();
            try
            {
                var nowTx = DateTime.Now.Ticks;
                _requestsTx.RemoveAll(tx => nowTx - tx >= _interval.Ticks);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        protected override void DisposeResources()
        {
            _mutex.Dispose();
        }
    }

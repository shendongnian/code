    public interface IWaitOnlyWaitHandle
    {
        bool WaitOne();
        bool WaitOne(TimeSpan timeout);
        bool WaitOne(int millisecondsTimeout);
        bool WaitOne(int millisecondsTimeout, bool exitContext);
        bool WaitOne(TimeSpan timeout, bool exitContext);
    }
    public sealed class WaitOnlyWaitHandle : IWaitOnlyWaitHandle
    {
        # UPDATE: this object does not own the passed in WaitHandle
        private readonly WaitHandle _waitHandle;
        public WaitOnlyWaitHandle(WaitHandle waitHandle)
        {
            _waitHandle = waitHandle;
        }
        public bool WaitOne() => _waitHandle.WaitOne();
        public bool WaitOne(TimeSpan timeout) => _waitHandle.WaitOne(timeout);
        public bool WaitOne(int millisecondsTimeout) => _waitHandle.WaitOne(millisecondsTimeout);
        public bool WaitOne(int millisecondsTimeout, bool exitContext) => _waitHandle.WaitOne(millisecondsTimeout, exitContext);
        public bool WaitOne(TimeSpan timeout, bool exitContext) => _waitHandle.WaitOne(timeout, exitContext);
    }

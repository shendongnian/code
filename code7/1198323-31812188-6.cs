    public class BeginEnd<T> : IDisposable
    {
        private Action<T> _end;
        private bool _disposed;
        private T _val;
        public BeginEnd(T val, Action<T> begin, Action<T> end)
        {
            _end = end;
            _val = val;
            begin(val);
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BeginEnd() { Dispose(false); }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) {
                if (disposing) {
                  _disposed = true;
                  _end(_val);
                }
            }
        }
    }

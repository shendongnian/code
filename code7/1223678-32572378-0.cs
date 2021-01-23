    public class BaseApiRequest<T> : IDisposable {
        private readonly ManualResetEvent _signal;
        private T _result;
        public BaseApiRequest() {
            _signal = new ManualResetEvent(false);
        }
        public T GetResult() {
            _signal.WaitOne();
            return _result;
        }
        public bool TryGetResult(TimeSpan timeout, out T result) {
            result = default(T);
            if (_signal.WaitOne(timeout)) {
                result = _result;
                return true;
            }
            return false;
        }
        public void SetResult(T result) {
            _result = result;
            _signal.Set();
            var handler = ResultReady;
            if (handler != null)
                handler(this, new ResultReadyEventArgs<T>(_result));
        }
        public void Dispose() {
            _signal.Dispose();
        }
        public event EventHandler<ResultReadyEventArgs<T>> ResultReady;
        public class ResultReadyEventArgs<T> : EventArgs {
            public ResultReadyEventArgs(T result) {
                this.Result = result;
            }
            public T Result { get; private set; }
        }
    }

    // this is common practice for genertic classes like BaseApiRequest<T> -
    // create parent class which does not have generic parameters
    public abstract class BaseApiRequest : IDisposable {
        public abstract void Dispose();
        public abstract void SetException(Exception ex);
    }
    public abstract class BaseApiRequest<T> : BaseApiRequest {
        private readonly ManualResetEventSlim _signal;
        private Exception _exception;
        private T _result;
        protected BaseApiRequest() {
            _signal = new ManualResetEventSlim(false);
        }
        public T GetResult() {
            _signal.Wait();
            if (_exception != null)
                throw new Exception("Exception during request processing. See inner exception for details", _exception);
            return _result;
        }
        public T GetResult(CancellationToken token) {
            _signal.Wait(token);
            if (_exception != null)
                throw new Exception("Exception during request processing. See inner exception for details", _exception);
            return _result;
        }
        public bool TryGetResult(TimeSpan timeout, out T result) {
            result = default(T);
            if (_signal.Wait(timeout)) {
                if (_exception != null)
                    throw new Exception("Exception during request processing. See inner exception for details", _exception);
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
        public override void SetException(Exception ex) {
            _exception = ex;
            _signal.Set();
            var handler = ResultReady;
            if (handler != null)
                handler(this, new ResultReadyEventArgs<T>(_exception));
        }
        public override void Dispose() {
            _signal.Dispose();
        }
        public event EventHandler<ResultReadyEventArgs<T>> ResultReady;
        public class ResultReadyEventArgs<T> : EventArgs {
            public ResultReadyEventArgs(T result) {
                this.Result = result;
                this.Success = true;
            }
            public ResultReadyEventArgs(Exception ex)
            {
                this.Exception = ex;
                this.Success = false;
            }
            public bool Success { get; private set; }
            public T Result { get; private set; }
            public Exception Exception { get; private set; }
        }
    }    

    public class RemoteCompletionSource<T> : CrossAppDomainObject
    {
        private readonly TaskCompletionSource<T> _tcs = new TaskCompletionSource<T>();
        
        public void SetResult(T result) { _tcs.SetResult(result); }
        public void SetException(Exception[] exception) { _tcs.SetException(exception); }
        public void SetCanceled() { _tcs.SetCanceled(); }
        public Task<T> Task => _tcs.Task;
    }

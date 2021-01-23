    internal sealed class Awaiter3
    {
        private volatile TaskCompletionSource<byte> _waiting;
        public void Pulse()
        {
            var w = _waiting;
            if (w == null)
            {
                return;
            }
            _waiting = null;
    #if NET_6_OR_GREATER
            w.TrySetResult(1);
    #else
            Task.Run(() => w.TrySetResult(1));
    #endif
            
        }
        public Task Wait()
        {
            if(_waiting != null)
                throw new InvalidOperationException("Only one waiter is allowed to exist at a time!");
    #if NET_6_OR_GREATER
            _waiting = new TaskCompletionSource<byte>(TaskCreationOptions.RunContinuationsAsynchronously);
    #else
            _waiting = new TaskCompletionSource<byte>();
    #endif
            return _waiting.Task;
        }
    }

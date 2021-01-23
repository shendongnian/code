    internal sealed class Awaiter3
    {
        private volatile TaskCompletionSource<byte> _waiting = new TaskCompletionSource<byte>();
        public void Pulse()
        {
    #if NET_6_OR_GREATER
            _waiting.TrySetResult(1);
    #else
            Task.Run(() => _waiting.TrySetResult(1));
    #endif
        }
        /// <summary>
        /// Only one waiter is allowed at a time!
        /// </summary>
        public Task Wait()
        {
    #if NET_6_OR_GREATER
            _waiting = new TaskCompletionSource<byte>(TaskCreationOptions.RunContinuationsAsynchronously);
    #else
            _waiting = new TaskCompletionSource<byte>();
    #endif
            return _waiting.Task;
        }
    }

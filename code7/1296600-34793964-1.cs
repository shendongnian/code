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
    #if NET_6_OR_GREATER
            w.TrySetResult(1);
    #else
            Task.Run(() => w.TrySetResult(1));
    #endif
    
        }
    
        /// <summary>
        /// Only one waiter is allowed at a time!
        /// </summary>
        public async Task Wait()
        {
    #if NET_6_OR_GREATER
            _waiting = new TaskCompletionSource<byte>(TaskCreationOptions.RunContinuationsAsynchronously);
    #else
            _waiting = new TaskCompletionSource<byte>();
    #endif
            await _waiting.Task.ConfigureAwait(false);
            _waiting = null;
        }
    }

    public class CallbackHandle<T>
    {
        public CallbackHandle(int timeout)
        {
            this.TaskCompletionSource = new TaskCompletionSource<T>();
            var cts = new CancellationTokenSource(timeout);
            cts.Token.Register(
                () =>
                    {
                        if (this.Cancelled != null)
                        {
                            this.Cancelled();
                        }
                    });
            this.CancellationToken = cts;
        }
        public event Action Cancelled;
        public CancellationTokenSource CancellationToken { get; private set; }
        public TaskCompletionSource<T> TaskCompletionSource { get; private set; }
    }

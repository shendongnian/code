    public class DelayedExecutor
    {
        private int timeout;
        private Task currentTask;
        private CancellationToken cancellationToken;
        private CancellationTokenSource tokenSource;
        public DelayedExecutor(int timeout)
        {
            this.timeout = timeout;
            tokenSource = new CancellationTokenSource();
        }
        public void AbortExecution()
        {
            if (currentTask != null)
            {
                if (!currentTask.IsCompleted)
                {
                    tokenSource.Cancel();
                }
            }
        }
        public Task DelayExecute(Action func)
        {
            AbortExecution();
            tokenSource = new CancellationTokenSource();
            cancellationToken = tokenSource.Token;
            return currentTask =
                Task.Delay(timeout, cancellationToken).ContinueWith(t =>
                {
                    if(!t.IsCanceled)
                    {
                        var sw = Stopwatch.StartNew();
                        func();
                        Debug.WriteLine("sw.ElapsedMilliseconds inside DelayExecute: " + sw.ElapsedMilliseconds);
                    }
                });
        }
    }

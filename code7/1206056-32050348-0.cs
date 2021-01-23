    public sealed class AsyncTimer : CancellationTokenSource
    {
        public AsyncTimer (Func<Task> callback, int millisecondsDueTime, int millisecondsPeriod)
        {
            Task.Run(async () =>
            {
                await Task.Delay(millisecondsDueTime, Token);
                while (!IsCancellationRequested)
                {
                    await callback();
                    if (!IsCancellationRequested)
                        await Task.Delay(millisecondsPeriod, Token).ConfigureAwait(false);
                }
            });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Cancel();
            base.Dispose(disposing);
        }
    }

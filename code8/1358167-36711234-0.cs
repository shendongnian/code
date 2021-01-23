    public static class CancellationTokenSourceExtensions
    {
        public static Task CancelAfter(this CancellationTokenSource cts, TimeSpan timeout)
        {
            return Task.Delay(timeout).ContinueWith(() => cts.Cancel());
        }
    }

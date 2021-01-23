    /// <summary>
    /// Contains extensions for threads.
    /// </summary>
    public static class ThreadExtensions
    {
        /// <summary>
        /// Allows sleeping with cancellation.
        /// </summary>
        /// <param name="thread">The reference to the thread itself.</param>
        /// <param name="sleep">The amount of time to sleep in milliseconds.</param>
        /// <param name="source">An instance of <see cref="CancellationTokenSource"/> which can be used to signal the cancellation.</param>
        public static void InterruptableSleep(this Thread thread, int sleep, CancellationTokenSource source)
        {
            while (!source.IsCancellationRequested && (sleep -= 5) > 0)
            {
                Thread.Sleep(5);
            }
        }
    }

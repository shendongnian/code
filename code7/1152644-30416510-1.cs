    while ((var messages = myQueueClient.ReceiveBatch(1000)) != null)
    {
        var sw = WaitableStopwatch.StartNew();
        // ReceiveBatch() return IEnumerable<>. No need for .ToList().
        foreach (var message in messages)
        {
            ...
        }
        // If processing took less than 10 seconds, sleep
        // for the remainder of that time span before getting
        // the next batch.
        sw.Wait(Timespan.FromSeconds(10));
    }
    /// <summary>
    /// Extends Stopwatch with the ability to wait until a specified
    /// elapsed time has been reached.
    /// </summary>
    public class WaitableStopwatch : Stopwatch
    {
        /// <summary>
        /// Initializes a new WaitableStopwatch instance, sets the elapsed
        /// time property to zero, and starts measuring elapsed time.
        /// </summary>
        /// <returns>A WaitableStopwatch that has just begun measuring elapsed time.</returns>
        public static new WaitableStopwatch StartNew()
        {
            WaitableStopwatch sw = new WaitableStopwatch();
            sw.Start();
            return sw;
        }
        /// <summary>
        /// Waits until the ElapsedMilliseconds property reaches <paramref name="elapsedMilliseconds"/>.
        /// </summary>
        /// <param name="elapsedMilliseconds"></param>
        public void Wait(int elapsedMilliseconds)
        {
            Wait(TimeSpan.FromMilliseconds(elapsedMilliseconds));
        }
        /// <summary>
        /// Waits until when the Elapsed property reaches <paramref name="elapsed"/>.
        /// </summary>
        /// <param name="elapsed"></param>
        public void Wait(TimeSpan elapsed)
        {
            TimeSpan diff;
            while ((diff = elapsed - this.Elapsed) > TimeSpan.Zero)
            {
                Thread.Sleep(diff);
            }
        }
        /// <summary>
        /// Waits until when the ElapsedMilliseconds property reaches <paramref name="elapsedMilliseconds"/>.
        /// </summary>
        /// <param name="elapsedMilliseconds"></param>
        public Task WaitAsync(int elapsedMilliseconds)
        {
            return WaitAsync(TimeSpan.FromMilliseconds(elapsedMilliseconds));
        }
        /// <summary>
        /// Waits until when the Elapsed property reaches <paramref name="elapsed"/>.
        /// </summary>
        /// <param name="elapsed"></param>
        public async Task WaitAsync(TimeSpan elapsed)
        {
            TimeSpan diff;
            while ((diff = elapsed - this.Elapsed) > TimeSpan.Zero)
            {
                await Task.Delay(diff);
            }
        }
    }

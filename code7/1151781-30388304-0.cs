    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// The Timer provides a means to start a timer with a callback that can be repeated over a set interval.
    /// </summary>
    /// <typeparam name="T">A generic Type</typeparam>
    public sealed class Timer<T> : CancellationTokenSource, IDisposable
    {
        /// <summary>
        /// The timer task
        /// </summary>
        private Task timerTask;
        /// <summary>
        /// How many times we have fired the timer thus far.
        /// </summary>
        private long fireCount = 0;
        /// <summary>
        /// Initializes a new instance of the <see cref="Timer{T}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        public Timer(T state)
        {
            this.StateData = state;
        }
        /// <summary>
        /// Gets the state data.
        /// </summary>
        /// <value>
        /// The state data.
        /// </value>
        public T StateData { get; private set; }
        /// <summary>
        /// Gets a value indicating whether the engine timer is currently running.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; private set; }
        /// <summary>
        /// Starts the specified start delay.
        /// </summary>
        /// <param name="startDelay">The start delay in milliseconds.</param>
        /// <param name="interval">The interval in milliseconds.</param>
        /// <param name="numberOfFires">Specifies the number of times to invoke the timer callback when the interval is reached. Set to 0 for infinite.</param>
        public void Start(double startDelay, double interval, int numberOfFires, Action<T, Timer<T>> callback)
        {
            this.IsRunning = true;
            this.timerTask = Task
                .Delay(TimeSpan.FromMilliseconds(startDelay), this.Token)
                .ContinueWith(
                    (task, state) => RunTimer(task, (Tuple<Action<T, EngineTimer<T>>, T>)state, interval, numberOfFires),
                    Tuple.Create(callback, this.StateData),
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.Default);
        }
        /// <summary>
        /// Starts the specified start delay.
        /// </summary>
        /// <param name="startDelay">The start delay in milliseconds.</param>
        /// <param name="interval">The interval in milliseconds.</param>
        /// <param name="numberOfFires">Specifies the number of times to invoke the timer callback when the interval is reached. Set to 0 for infinite.</param>
        public void StartAsync(double startDelay, double interval, int numberOfFires, Func<T, Timer<T>, Task> callback)
        {
            this.IsRunning = true;
            this.timerTask = Task
                .Delay(TimeSpan.FromMilliseconds(startDelay), this.Token)
                .ContinueWith(
                    async (task, state) => await RunTimerAsync(task, (Tuple<Func<T, Timer<T>, Task>, T>)state, interval, numberOfFires),
                    Tuple.Create(callback, this.StateData),
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.Default);
        }
        /// <summary>
        /// Stops the timer for this instance. It is not 
        /// </summary>
        public void Stop()
        {
            if (!this.IsCancellationRequested)
            {
                this.Cancel();
            } 
            this.IsRunning = false;
        }
        /// <summary>
        /// Cancels the timer and releases the unmanaged resources used by the <see cref="T:System.Threading.CancellationTokenSource" /> class and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.IsRunning = false;
                this.Cancel();
            }
            base.Dispose(disposing);
        }
        private async Task RunTimer(Task task, Tuple<Action<T, EngineTimer<T>>, T> state, double interval, int numberOfFires)
        {
            while (!this.IsCancellationRequested)
            {
                // Only increment if we are supposed to.
                if (numberOfFires > 0)
                {
                    this.fireCount++;
                }
                state.Item1(state.Item2, this);
                await PerformTimerCancellationCheck(interval, numberOfFires);
            }
        }
        private async Task RunTimerAsync(Task task, Tuple<Func<T, EngineTimer<T>, Task>, T> state, double interval, int numberOfFires)
        {
            while (!this.IsCancellationRequested)
            {
                // Only increment if we are supposed to.
                if (numberOfFires > 0)
                {
                    this.fireCount++;
                }
                await state.Item1(state.Item2, this);
                await PerformTimerCancellationCheck(interval, numberOfFires);
            }
        }
        private async Task PerformTimerCancellationCheck(double interval, int numberOfFires)
        {
            // If we have reached our fire count, stop. If set to 0 then we fire until manually stopped.
            if (numberOfFires > 0 && this.fireCount >= numberOfFires)
            {
                this.Stop();
            }
            await Task.Delay(TimeSpan.FromMilliseconds(interval), this.Token).ConfigureAwait(false);
        }
    }

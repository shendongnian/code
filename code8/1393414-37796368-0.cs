    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using Timer = System.Timers.Timer;
    namespace Throttler
    {
        public abstract class ExecutionThrottler<TParameters> : IDisposable
        {
            private readonly Action<TParameters> _action;
            private readonly int _executionsPerInterval;
            private readonly ConcurrentQueue<TParameters> _queue = new ConcurrentQueue<TParameters>();
            private bool _processingQueue;
            private readonly object _processingQueueLock = new object();
            private long _executionsSinceIntervalStart;
            private readonly Timer _timer;
            bool _disposed;
            protected ExecutionThrottler(Action<TParameters> action, TimeSpan interval, int executionsPerInterval)
            {
                _action = action;
                _executionsPerInterval = executionsPerInterval;
                _timer = new Timer(interval.TotalMilliseconds);
                _timer.AutoReset = true;
                _timer.Start();
                _timer.Elapsed += OnIntervalEnd;
            }
            public void Enqueue(TParameters parameters)
            {
                _queue.Enqueue(parameters);
            }
            private void TryProcessQueue()
            {
                if (_processingQueue) return;
                lock (_processingQueueLock)
                {
                    if (_processingQueue) return;
                    _processingQueue = true;
                    try
                    {
                        ProcessQueue();
                    }
                    finally
                    {
                        _processingQueue = false;
                    }
                }
            }
            private void ProcessQueue()
            {
                TParameters dequeuedParameters;
                while (!MaxExecutionsPerIntervalReached() && _queue.TryDequeue(out dequeuedParameters))
                {
                    IncrementExecutionsSinceIntervalStart();
                    _action.Invoke(dequeuedParameters);
                }
            }
            private void OnIntervalEnd(object sender, System.Timers.ElapsedEventArgs e)
            {
                ResetExecutionsSinceIntervalStart();
                TryProcessQueue();
            }
            private void IncrementExecutionsSinceIntervalStart()
            {
                Interlocked.Increment(ref _executionsSinceIntervalStart);
            }
            private void ResetExecutionsSinceIntervalStart()
            {
                Interlocked.Exchange(ref _executionsSinceIntervalStart, 0);
            }
            private bool MaxExecutionsPerIntervalReached()
            {
                var executions = Interlocked.Read(ref _executionsSinceIntervalStart);
                return executions >= _executionsPerInterval;
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            ~ExecutionThrottler()
            {
                Dispose(false);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                    return;
                if (disposing)
                {
                    _timer.Dispose();
                }
                _disposed = true;
            }
        }
    }

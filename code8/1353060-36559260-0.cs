        delegate void TimerCallback(object state);
    
        sealed class Timer : CancellationTokenSource, IDisposable
        {
            internal Timer(TimerCallback callback, object state, int dueTime, int period)
            {
                if (dueTime <= 0)
                    throw new ArgumentOutOfRangeException("dueTime", "Must be positive integer");
    
                if (period <= 0)
                    throw new ArgumentOutOfRangeException("period", "Must be positive integer");
                
                Task.Delay(dueTime, Token).ContinueWith(async (t, s) =>
                    {
                        var tuple = (Tuple<TimerCallback, object>)s;
    
                        while (true)
                        {
                            if (IsCancellationRequested)
                                break;
                            Task.Run(() => tuple.Item1(tuple.Item2));
                            await Task.Delay(period);
                        }
    
                    }, Tuple.Create(callback, state), CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.Default);
            }
    
            public new void Dispose()
            {
                Cancel();
            }
        }

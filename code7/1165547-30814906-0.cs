        class Schedule : IObservable<DateTime>
        {
            readonly TimeSpan TimerPrecision = TimeSpan.FromMilliseconds(1);
            readonly IEnumerable<TimeSpan> Intervals;
            readonly IEnumerator<DateTime> Event;
            public Schedule()
                : this(new TimeSpan[0])
            {
            }
            Schedule(IEnumerable<TimeSpan> intervals)
            {
                Intervals = intervals;
                Event = Start();
                Event.MoveNext();
            }
            public Schedule Setup(TimeSpan interval)
            {
                return Setup(interval, Int32.MaxValue);
            }
            public Schedule Setup(TimeSpan interval, int repeat)
            {
                return new Schedule(
                    Intervals.Concat(
                        Enumerable.Repeat(interval, repeat)));
            }
            
            public IDisposable Subscribe(IObserver<DateTime> observer)
            {
                var timer = new System.Timers.Timer() { AutoReset = true };
                timer.Elapsed += (s, a) => 
                {                                                
                    observer.OnNext(DateTime.UtcNow);
                    if (!TryArm(timer))
                        observer.OnCompleted();
                };
                if (!TryArm(timer))
                    observer.OnCompleted();
                return timer;
            }
            IEnumerator<DateTime> Start()
            {
                var time = DateTime.UtcNow;
                yield return time;
                foreach (var interval in Intervals)
                {
                    time += interval;
                    yield return time;
                }
            }
            TimeSpan Delay()
            {
                var now = DateTime.UtcNow;
                lock (Event)
                    while (Event.Current - DateTime.UtcNow < TimerPrecision)
                        Event.MoveNext();
                return Event.Current - now;
            }
            bool TryArm(System.Timers.Timer timer)
            {
                try
                {
                    timer.Interval = Delay().TotalMilliseconds;
                    timer.Start();
                    return true;
                }            
                catch(InvalidOperationException)   
                {
                    return false;
                }
            }
        }

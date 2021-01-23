        public static IObservable<T> GenerateAsync<T>(TimeSpan span, 
                                                      Func<int, Task<T>> generator, 
                                                      IScheduler scheduler = null)
        {
            scheduler = scheduler ?? Scheduler.Default;
            return Observable.Create<T>(obs =>
            {
                return scheduler.Schedule(0, span, async (idx, recurse) =>
                {
                    obs.OnNext(await generator(idx));
                    recurse(idx + 1, span);
                });
            });
        }

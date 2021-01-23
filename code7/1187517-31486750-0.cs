    public static IObservable<TResult> Generate<TResult>(
        Func<Task<TResult>> initialState,
        Func<TResult, bool> condition,
        Func<TResult, Task<TResult>> iterate,
        Func<TResult, TResult> resultSelector,
        IScheduler scheduler = null) 
    {
      var s = scheduler ?? Scheduler.Default;
      return Observable.Create<TResult>(async obs => {
        return s.Schedule(await initialState(), async (state, self) => 
        {
          if (!condition(state))
          {
            obs.OnCompleted();
            return;
          }
          obs.OnNext(resultSelector(state));
 
          self(await iterate(state));
          
        });
      });
    }

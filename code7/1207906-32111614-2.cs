    public static IObservable<TOut> GenerateAsync<TResult, TOut>(
        Func<Task<TResult>> initialState,
        Func<TResult, bool> condition,
        Func<TResult, Task<TResult>> iterate,
        Func<TResult, TimeSpan> timeSelector,
        Func<TResult, TOut> resultSelector,
        IScheduler scheduler = null) 
    {
      var s = scheduler ?? Scheduler.Default;
    
      return Observable.Create<TOut>(async obs => {
        //You have to do your initial time delay here.
        var init = await initialState();
        return s.Schedule(init, timeSelector(init), async (state, recurse) => 
        {
          //Check if we are done
          if (!condition(state))
          {
            obs.OnCompleted();
            return;
          }
          //Process the result
          obs.OnNext(resultSelector(state));
          //Initiate the next request
          state = await iterate(state);
          
          //Recursively schedule again
          recurse(state, timeSelector(state));
    
        });
      });
    }

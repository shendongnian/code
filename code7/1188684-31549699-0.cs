    public static IObservable<string> GetFileSource(string path, Func<string, Task<string>> processor, IScheduler scheduler = null) {
      scheduler = scheduler ?? Scheduler.Default;
    
      return Observable.Create<string>(obs => 
      {
        //Grab the enumerator as our iteration state.
        var enumerator = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
                                  .GetEnumerator();
        return scheduler.Schedule(enumerator, async (e, recurse) =>
        {
          if (!e.MoveNext())
          {
             obs.OnCompleted();
             return;
          }
    
          //Wait here until processing is done before moving on
          obs.OnNext(await processor(e.Current));
          
          //Recursively schedule
          recurse(e);
        });
      });
    }

    public void DoWork(Action action)
    {
         _task = Task.Factory.StartNew(action).ContinueWith((previousTask) => 
           {
               foreach (var innerEx in ex.InnerExceptions)
               {
                    Logger.Log(innerEx);
               }
            }, TaskContinuationOptions.OnlyOnFaulted);
    }

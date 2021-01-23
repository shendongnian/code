     public void RunTask(Action action){
       var task = new Task(action, cancellationTokenSource.Token);
     Task nextTask = task.ContinueWith(x =>
       {
           DoSomething();
       }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext());
 
           task.Start();
         }
    
    public void DoSomething()
    {
        if(condition) // condition is true in this case (it's recurency but not permanent)
        RunTask(() => Method()); // method is being passed which blocks UI when invoked in RunTask method
    }
    public void Method()
    {
      LongRunningMethod();
    }

    static class EventScheduler
    {
 
      public static TaskScheduler TaskScheduler
      {
          get {return _taskScheduler; }
          set {_taskScheduler = value; }
      }   
      static TaskScheduler _taskScheduler = TaskScheduler.Default;
      public static Task RunAsync(Action<T> action)
      {
          return Task.Factory.StartNew(() => {c = value;}, 
           CancellationToken.None, TaskCreationOptions.DenyChildAttach,
          _taskScheduler);
       }
    }
    class B 
    {
       public void RaiseAsyncEvent(int value)
       {
           EventScheduler.RunAsync(()=>{c = value;});
       }
     }
     // Unit test
     var schedulerPair = new ConcurrentExclusiveSchedulerPair();
     EventScheduler.TaskScheduler = schedulerPair.ConcurrentScheduler;
     B b = new B();
     A.OnIntChange += b.RaiseAsyncEvent;    
     A.a = 10;
     schedulerPair.Complete();
     schedulerPair.Completion.Wait();
     Assert.AreEqual(10, A.b.c);

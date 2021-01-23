    class B {
       public B(TaskScheduler taskScheduler)
       {
          _taskScheduler = taskScheduler;
       }   
       
       public B(): this(TaskScheduler.Default)
       {
       }
       public void RaiseAsyncEvent(int value)
       {
           Task.Factory.StartNew(() => {c = value;}, 
             TaskCreationOptions.DenyChildAttach, _taskScheduler);
       }
       TaskScheduler _taskScheduler;
    }

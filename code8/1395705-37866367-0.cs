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
    // Unit test
     var taskScheduler = new TestTaskScheduler();
     B b = new B(taskScheduler);
     A.OnIntChange += b.RaiseAsyncEvent;    
     A.a = 10;
     taskScheduler.WaitForCompletion();
     Assert.AreEqual(10, A.b.c);

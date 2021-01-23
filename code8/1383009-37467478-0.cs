    private static lock locker = new object();
    public MyMethod()
    {
      if (i==5)
      {
         lock(locker)
         {
            if (i==5) // is it really == or should it be >=
            { 
              resetEvent.WaitOne();
            }
         }
      }
      
      //i was not 5, do whatever other work that needs to be done.
      //at some point you would want to decrement i and signal
      //either here or some other method that is finishing the task
    
      Interlocked.Decrement(ref i);
      if (i < 5)
      {
          resetEvent.Set();
      }
    }

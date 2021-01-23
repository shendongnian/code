    public class MyThreadingClass
    {
       int threadCount = 0;
       public void DoLotsOfWork()
       {
          Task.Factory.StartNew(() => SomeMethod());
       }
       public void SomeMethod()
       {
          Interlocked.Increment(threadCount);
          try
          {
             // Some Code
          }
          finally
          {
             Interlocked.Decrement(threadCount);
          }
       }
    }

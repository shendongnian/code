    public class MyLock : IDisposable
    {
         private object lockObj;
         public MyLock(lockObj)
         {
              this.lockObj = lockObj;
              if(!Monitor.TryEnter(this.lockObj, timeout))
                  throw new TimeoutException();
         }
    
         public void Dispose()
         {
               Monitor.Exit(lockObj)
         }
    }

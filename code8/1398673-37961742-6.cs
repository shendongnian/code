    using System;
    using System.Threading; 
   
    public class MyLock : IDisposable
    {
        private object lockObj;
        public Lock(object lockObj, TimeSpan timeout)
        {
            this.lockObj = lockObj;
            if (!Monitor.TryEnter(this.lockObj, timeout))
                throw new TimeoutException();
        }
        public void Dispose()
        {
            Monitor.Exit(lockObj);
        }
    }

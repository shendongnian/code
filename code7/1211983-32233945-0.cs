    public class LockWrapper<T>:IDisposable
        where T:IDisposable
    {
        T obj;
        object lockObject ;
        public LockWrapper(T obj, string Name)
             :this(()=>obj, Name)
        {
        }   
    
        public LockWrapper(Func<T> objcreator, string Name)
        {
            lockObject = myLockHelper.GetUniqueObjectForLocking("path");
            Monitor.Enter(lockObject);
            this.obj = objcreator();
        }
        public T Object{get{return obj;}}
    
        public void Dispose()
        {
            try
            {
                obj.Dispose();
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
    }
    //helper inside a static class
    public static LockWrapper<T> StartLock(this T obj, string LockName)
        where T:IDisposable
    {
        return new LockWrapper<T>(obj, LockName);
    }

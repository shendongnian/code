    class LockedResource
    {
        ReaderWriterLockSlim resourceLock;
        Func<bool> process;
        public LockedResource(Func<bool> work)
        {
            resourceLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            process = work;
        }
        public bool DoWork(string name,int? timeout=null)
        {
            try
            {
                if(timeout!=null)
                {
                    resourceLock.TryEnterWriteLock(timeout.Value);
                }
                else
                {
                    resourceLock.EnterWriteLock();
                }
                Console.WriteLine("Resouce accessed by {0}",name);
                if (process != null)
                {
                    return process();
                }
            }
            finally
            {
                Console.WriteLine("{0} releasing resouce", name);
                resourceLock.ExitWriteLock();
            }
            return false;
        }
    }

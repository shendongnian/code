    
    class LockedResource
    {
        public delegate void RefAction();
        ReaderWriterLockSlim resourceLock;
        
        public LockedResource()
        {
            //Warning: SupportsRecursion is risky, you should remove support for recursive whenever possible
            resourceLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }
        public bool DoWork(RefAction work, string threadname, int timeout = -1)
        {
            try
            {
                if (resourceLock.TryEnterWriteLock(timeout))
                {
                    if (work != null)
                    {
                        work();
                    }
                }
                else
                {
                    Console.WriteLine("Lock time out on thread {0}", threadname);
                }
            }
            finally
            {
                Console.WriteLine("{0} releasing resource", threadname);
                if(resourceLock.IsWriteLockHeld)
                {
                    resourceLock.ExitWriteLock();
                }
            }
            return false;
        }
    }

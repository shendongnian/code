    public interface ILocker
    {
        bool GetLock();
        void Release();
    }
    class Locker : ILocker
    {
        private long m_NumberOfTimeGetLockWasCalled = 0;
        private readonly object m_LockingObject = new object();
        private readonly object m_LockingObject2 = new object();
        public bool GetLock()
        {
            long lock_count = 0;
            var lock_was_taken = false;
            lock(m_LockingObject)
            {
                lock_count = m_NumberOfTimeGetLockWasCalled++;
                lock_was_taken = Monitor.TryEnter(m_LockingObject2);
                if (lock_was_taken)
                    return true;
            }
            while(!lock_was_taken)
            {
                Thread.Sleep(5);
                lock(m_LockingObject)
                {
                    if (lock_count != m_NumberOfTimeGetLockWasCalled)
                        return false;
                    lock_was_taken = Monitor.TryEnter(m_LockingObject2);
                    if (lock_was_taken)
                        break;
                }
                
            }
            return true;
        }
        public void Release()
        {
            Monitor.Exit(m_LockingObject2);
        }
    }

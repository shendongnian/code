    namespace MyNameSpace
    {
        public delegate void LockWrapperDelegateVoid();
    
        /* Job Locker. One job can work at current moment. Different jobs can work parallel */
        public static class JobLocker
        {
            private static readonly ConcurrentDictionary<string, bool> _locks = new ConcurrentDictionary<string, bool>();
    
            private static string LocksTryAdd(string lockerName)
            {
                if (string.IsNullOrEmpty(lockerName))  // lock by procedure's name (in this example = "JobProcedure")
                {
                    lockerName = new StackFrame(2).GetMethod().Name;
                }
                if (!_locks.ContainsKey(lockerName))
                {
                    _locks.TryAdd(lockerName, false);
                }
                return lockerName;
            }
    
            public static void LockWrapperVoid(string lockerName, LockWrapperDelegateVoid lockWrapperDelegateVoid)
            {
                lockerName = LocksTryAdd(lockerName);
                if (!_locks[lockerName])
                {
                    _locks[lockerName] = true;
                    try
                    {
                        lockWrapperDelegateVoid();
                    }
                    finally
                    {
                        _locks[lockerName] = false;
                    }
                }
            }
        }
    }
    
    // USING
    
    // JOB description
    TryAddOrUpdateJob("JOB TITLE", () => JobManager.JobProcedure(), "* * * * *", TimeZoneInfo.Utc, "queueDefault");  // every one minute
    
    
    public static void JobProcedure()
    {
        // very important. You can use "BlockArea" instead null and use one area if several jobs depend each other
        // if null - area will have name like as the procedure ("JobProcedure")
        JobLocker.LockWrapperVoid(null, () =>  
        {
            //your code here
            System.Threading.Thread.Sleep(2 * 1000 * 60); // timeout - 2 minutes
        });
    }

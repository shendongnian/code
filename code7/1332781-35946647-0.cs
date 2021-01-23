    public static class DynamicLock
    {
        private static Dictionary<string, AsyncLock> LockList = new Dictionary<string, AsyncLock>();
        private static readonly object lockDic = new AsyncLock();
        public static async Task<T> LockOnKey<T>(string lockKey, Func<Task<T>> criticalFunc)
        {
            AsyncLock obj = null;
            lock (lockDic)
            {
                
                if (!LockList.TryGetValue(lockKey, out obj))
                {
                    obj = new AsyncLock();
                    LockList.Add(lockKey, obj);
                }
            }
            using (var releaser = await obj.LockAsync().ConfigureAwait(false))
            { 
                return await criticalFunc();
            }
        }
    }

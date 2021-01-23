    public static class MySimpleCache
    {
        private static readonly SynchronizedCollection<KeyValuePair<string, string>> Collection = new SynchronizedCollection<KeyValuePair<string, string>>();
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
        public static string Get(string key, Func<string> getter)
        {
            //This allows multiple readers to run concurrently.
            Lock.EnterReadLock();
            try
            {
                var result = Collection.FirstOrDefault(kvp => kvp.Key == key);
                if (!Object.Equals(result, default(KeyValuePair<string, string>)))
                {
                    return result.Value;
                }
            }
            finally
            {
                Lock.ExitReadLock();
            }
            var data = getter();
            //This blocks all future EnterReadLock(), once all finish it allows the function to continue
            Lock.EnterWriteLock();
            try
            {
                Collection.Add(new KeyValuePair<string, string>(key, data));
                return data;
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
    }

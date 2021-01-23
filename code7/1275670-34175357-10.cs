    class A
    {
        private int _cachedData;
        private readonly static object _getDataSyncLock = new object();
        private int GetData()
        {
            return 1;
        }
        public Task<int> GetPreviousDataAsync(out int cachedData)
        {
            // This will force calls to this method to be executed one by one, avoiding
            // N calls to his method update _cachedData class field in an unpredictable way
            lock(_getDataSyncLock)
            {
                Task<int> getDataTask = Task.Run(() => GetData());
                cachedData = _cachedData; // some previous value
                // Once the getDataTask has finished, this will set the 
                // _cachedData class field. Since it's an asynchronous 
                // continuation, the return statement will be hit before the
                // task ends, letting the caller await for the asynchronous
                // operation, while the method was able to output 
                // previous _cachedData using the "out" parameter.
                getDataTask.ContinueWith
                (
                    t => _cachedData = t.Result
                );
                return getDataTask;
            }
        }
        public void DoStuff()
        {
            int previousCachedData;
            // Don't await it, when the underlying task ends, sets
            // _cachedData already. This is like saying "fire and forget it"
            GetPreviousDataAsync(out previousCachedData);
        }
    }

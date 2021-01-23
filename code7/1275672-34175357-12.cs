    class A
    {
        private int _cachedData;
        private readonly static AutoResetEvent _getDataResetEvent = new AutoResetEvent(true);
        private int GetData()
        {
            return 1;
        }
        public Task<int> GetPreviousDataAsync(out int cachedData)
        {
            // This will force calls to this method to be executed one by one, avoiding
            // N calls to his method update _cachedData class field in an unpredictable way
            // It will try to get a lock in 6 seconds. If it goes beyong 6 seconds it means that 
            // the task is taking too much time. This will prevent a deadlock
            if (!_getDataResetEvent.WaitOne(TimeSpan.FromSeconds(6)))
            {
                throw new InvalidOperationException("Some previous operation is taking too much time");
            }
            // It has acquired an exclusive lock since WaitOne returned true
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
                t =>
                {
                    if (t.IsCompleted)
                        _cachedData = t.Result;
                    // Open the door again to let other calls proceed
                    _getDataResetEvent.Set();
                }
            );
            return getDataTask;
        }
        public void DoStuff()
        {
            int previousCachedData;
            // Don't await it, when the underlying task ends, sets
            // _cachedData already. This is like saying "fire and forget it"
            GetPreviousDataAsync(out previousCachedData);
        }
    }

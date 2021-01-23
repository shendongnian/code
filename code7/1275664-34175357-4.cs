    class A
    {
        private int _cachedData;
    
        public async Task GetPreviousDataAsync(out int cachedData)
        {
            Task<int> t = new Task<int>(() => getData());
            Task.Run(t);
            
            cachedData = _cachedData; // some previous value
            // Interlocked will synchronize _cachedData so only a single
            // thread will be able to set _cachedData
            // Also, since we're awaiting the task "t", this sentence will
            // be executed once the task "t" has finished sucessfully
            Interlocked.Exchange(ref _cachedData, await t);
        }
    
        public void DoStuff()
        {
            int previousCachedData;
            // Don't await it, when the underlying task ends, sets
            // _cachedData already
            GetPreviousDataAsync(out int previousCachedData);
        }
    }

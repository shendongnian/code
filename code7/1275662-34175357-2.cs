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
            Interlocked.Exchange(ref _cachedData, await t);
        }
    
        public void DoStuff()
        {
            int previousCachedData;
            // Don't await it, when the underlying task ends, sets
            // _cachedData too
            GetPreviousDataAsync(out int previousCachedData);
        }
    }

    public Task<int> GetPreviousDataAsync(out int cachedData)
    {
        Task<int> t = new Task<int>(() => getData());
        Task.Run(() => t);
        cachedData = _cachedData; // some previous value
        return t; // _cachedData == 2
    }
    
    int cachedData;
    cachedData = await GetPreviousDataAsync(out int cachedData);

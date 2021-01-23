    public async Task<DataResponse[]> GetGridDataAsync(DataRequest[] requestCollection, object state)
    {
        return Task.Factory.FromAsync<DataResponse[]>(BeginGetDataAsync(requestCollection, ar => EndGetDataAsync(ar), state), 
            EndGetDataAsync);
    }

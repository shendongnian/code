    async public Task<ResultType> CallMethodAsync()
    {
        foreach(var obj in input)
        {
            var singleResult = await CallDatabaseAsync(obj);
            // combine results if needed
        }
        // return combined results    
    }

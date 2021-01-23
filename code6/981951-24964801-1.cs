    public async Task PoolAndWaitAsync(int timeToWait)
    {
        var httpClient = new HttpClient();
        while (true)
        { 
            // Query database
            var data = await MyDatabase.QueryAsync(..);
            if (data != null)
            { 
                 var response = await httpClient.PostAsync(..);
            }
            await Task.Delay(timeToWait);
       }
    }

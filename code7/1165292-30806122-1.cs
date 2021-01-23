    public Task<bool> DoHeavyWork()
    {
        return Task.Run<bool>(() => 
            //do the heavy work
            return boolResult;
        );
    }

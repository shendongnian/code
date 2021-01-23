    public Task<bool> DoHeavyWork()
    {
        return Task.Run<bool>(() => 
            //do the work
            return boolResult;
        );
    }

     public Task<StatePropertyEx> RequestStateForEntity(EntityKey entity, string propName, CancellationToken token)
    {
        var tcs = new TaskCompletionSource<StateInfo>();
        try
        {
            // Cache checking
            _evtClient.SubmitStateRequest(entity, propName, token);
            return tcs.Task;
        }
        catch (Exception ex)
        {
            tcs.SetException(ex);
            return tcs.Task;
        }
    }

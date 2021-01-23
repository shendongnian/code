    public async Task<Entity> GetEntityAsync()
    {
        Entity result = await _entity.Task;
        _entity = _new TaskCompletionSource<Entity>();
        return result;
    }

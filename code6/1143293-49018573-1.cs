    private ISession _session;
    
    public async Task<T> GetAsync<T>(int id) where T : ISomeEntity
    {
        return await _session.GetAsync<T>(id);
    }

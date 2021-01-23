    public async Task<TKey?> SaveAsync<TKey>(IGraph builder, IDataContext context = null) where TKey : struct
    {
        ...
        return parameters.Get<TKey?>(key.ResolvedName).GetValueOrDefault();
    }

    public async Task<IEnumerable<Log_Header>> GetHeaderWithLastDetailAsync()
    {
        var headerTask = GetLogHeadersAsync();
        var detailTask = GetLastDetailByHeaderIdAsync();
    
        await Task.WhenAll(headerTask, detailTask).ConfigureAwait(false);
    
        var header = headerTask.Result;
        var detail = detailTask.Result;
    
        foreach(var h in header)
        {
            Log_Detail d;
            if(detail.TryGetValue(h.Id, out d)
                h.Details.Add(d);
        }
    }
    public async Task<IEnumerable<Log_Header>> GetLogHeadersAsync()
    {
        using(var context = new MyContext())
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            return await context.LogHeader.ToListAsync().ConfigureAwait(false);
        }
    }
    public async Task<IDictionary<int, Log_Detail>> GetLastDetailByHeaderIdAsync()
    {
        using(var context = new MyContext())
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            return await context.LogDetail.ToDictionaryAsync(d => d.HeaderId).ConfigureAwait(false);
        }
    }

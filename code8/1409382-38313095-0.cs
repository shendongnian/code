    public async Task<List<string>> GetAllQueriesAsync()
    { 
       var tasks = 
           Enumerable.Range(0, 10)
                     .Select(i => GetQueriesForIdAsync(i));
       await Task.WhenAll(tasks);
       return tasks.SelectMany(t => t.Result).ToList();
    }

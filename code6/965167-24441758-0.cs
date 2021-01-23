    public async Task<bool> AllAsync(this IEnumerable<Task<bool>> checkers)
    {
        var tasks = checkers.ToList();
    
        while(tasks.Count != 0)
        {
            var finishedTask = await Task.WhenAny(tasks);
    
            if(! finishedTask.Result)
                return false;
    
            tasks.Remove(finishedTask);
        }
    
        return true;
    }

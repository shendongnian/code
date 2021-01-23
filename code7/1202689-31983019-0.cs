    private async Task ActionAsync(T item)
    {
        doSomeStuff();   
        await mongoItems.FindOneAndUpdateAsync(mongoMumboJumbo);
        await AddBlah(SqlMumboJumbo);
    }
    private async Task MyFunction(IEnumerable<T> items)
    {
        try
        {
            foreach (var item in items)
            {
                tasks.Add( ActionAsync(item) )
            }
            // while all actions are running do something useful
            // when needed await for all tasks to finish:
            await Task.WhenAll(tasks);
            // interpret the result of each action using property Task.Result
        }
        catch (AggregateException exc)
        {
            ProcessAggregateException(exc);
        }
    }

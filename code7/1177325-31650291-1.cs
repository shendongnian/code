    private async void OnButton1_clicke(object Sender, ...)
    {
        try
        {
            await ProcessAllInputsAsync(...)
        }
        catch (ArgumentException exc)
        {
            ProcessArgumentException(...)
        }
        catch (Exception exc)
        {
             ProcessOtherException(...)
        }           
    }
    
    // first example: no parallel processing:
    private async Task ProcessAllInputsAsync(...)
    {   
        foreach (SomeVariable someVariable in GetSomeVariables(...))
        {
            DataTable dataTable = await GetResultAsync(...);
            ProcessDataTable(dataTable);
        }
    }
    // or do parallel processing: start several tasks and wait until all ready:
    private async Task ProcessAllInputsAsync(...)
    { 
        List<Task<DataTable>> tasks = new List<Task<DataTable>>();  
        foreach (SomeVariable someVariable in GetSomeVariables(...))
        {
            tasks.Add(GetResultAsync(someVariable);
        }
        // all tasks are started, await for all to finish:
        await Task.WhenAll(tasks.ToArray());
        // REMEMBER: you can only await for a Task or Task<T>
        // Task.WhenAll returns a Task, so you can await for it
        // Task.WaitAll returns void, so you can't await for it.
        // now that all tasks are finished, get the results:
        // Each Task<TResult> has the result in property Task.Result
        // The result of a Task<TResult> is a TResult:
        IEnumerable<TResult> fetchedDataTables = tasks.Select(task => task.Result);
        // you can process it here if you want or do other things with it:
        foreach (DataTabe fetchedDataTable in fetchedDataTables)
        {
            ProcessFetchedDataTable(fetchedDataTable);
        }
    }

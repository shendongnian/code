    private async void Sync_Click(object sender, EventArgs e)
    {
        CancellationToken token = new CancellationToken();
        await SyncAllMappings(token);            
        // Do whatever you want here, e.g. raising an event
    }
    
    async Task SyncAllMappings(CancellationToken token)
    {
        //create collection of tasks per each mapping
        IEnumerable<Task<Task>> tasks = SomeLogicHere();
    
        await Task.WhenAll(tasks);
    }

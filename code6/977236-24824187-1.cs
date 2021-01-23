    public async Task UpdateDatabses(List<string> databses)
    {
    	List<Task> updateTasks = new List<Task>();
    	
    	foreach (var db in databses)
    	{
    		updateTasks.Add(UpdateDatabase(db));
    	}
    	
    	// asynchronously wait for all the tasks to complete
    	await Task.WhenAll(updateTasks);
    }
    
    public async Task UpdateDatabase(string databse)
    {
    	await /* Update the database */
    }

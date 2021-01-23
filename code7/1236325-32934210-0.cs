    static void Main(string[] args)
    {
    	//---- queue commands into a "batch"
    	List<Task> toBeExecuted  = new List<Task>();
    	toBeExecuted.Add(Task.Run(() => dothing()));
    	toBeExecuted.Add(Task.Run(() => dothing()));
    	toBeExecuted.Add(Task.Run(() => dothing()));
    	toBeExecuted.Add(Task.Run(() => dothing()));
    	toBeExecuted.Add(Task.Run(() => dothing()));
    
    			
    	//---- elsewhere
    	Task.WaitAll(toBeExecuted.ToArray()); //fire off the batch
    	await brick.BatchCommand.SendCommandAsync(); //send to brick
    }

	public async Task SaveFilesAsync(string path, List<Tuple<int, string>> list, CancellationToken ct)
	{
		// setup the degree of parallelism you want, here using the number of processors, run everything on the default TaskScheduler which will use ThreadPool threads, and assign the CancellationToken
		var options = new ParallelOptions
						  {
							  CancellationToken = ct,
							  MaxDegreeOfParallelism = Environment.ProcessorCount,
							  TaskScheduler = TaskScheduler.Default
						  };
		// waiting on the result of the Parallel here, 
		// but that is up to you, not necessary and only here 
		// for logging purposes after it completed
		//
		// You pass in the list of items to process, each action
		// will receive an item from that list, along with a state object.
		var result = Parallel.ForEach(
			list,
			options,
			(item, state) =>
				{
					// build your path, item.Item1 being the file index
					string fullPath = string.Format(@"{0}\{1}_element.txt", path, item.Item1);
					
					using (var sw = File.CreateText(fullPath))
					{
						// write the file content
						// no need to write async here as the entire write in a separate operation (thank for pointing it out Paulo Morgado
						sw.WriteLine(item.Item2);
					}
					
					Debug.Print(
						"Saved in thread: {0} to {1}", 
						Thread.CurrentThread.ManagedThreadId, fullPath);
				});
		Debug.Print("Completed:{0} Break Index:{1}", 
			result.IsCompleted, result.LowestBreakIteration);
	}
    

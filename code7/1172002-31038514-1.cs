	public async Task SaveFilesAsync(string path, List<string> list, CancellationToken token)
	{
		int counter = 0;
		var options = new ParallelOptions
						  {
							  CancellationToken = token,
							  MaxDegreeOfParallelism = Environment.ProcessorCount,
							  TaskScheduler = TaskScheduler.Default
						  };
		await Task.Run(
			() =>
				{
					try
					{
						Parallel.ForEach(
							list,
							options,
							(item, state) =>
								{
									// if cancellation is requested, this will throw an OperationCanceledException caught outside the Parallel loop
									options.CancellationToken.ThrowIfCancellationRequested();
									// safely increment and get your next file number
									int index = Interlocked.Increment(ref counter);
									string fullPath = string.Format(@"{0}\{1}_element.txt", path, index);
									using (var sw = File.CreateText(fullPath))
									{
									    sw.WriteLine(item);
									}
									Debug.Print(
										"Saved in thread: {0} to {1}",
										Thread.CurrentThread.ManagedThreadId,
										fullPath);
								});
					}
					catch (OperationCanceledException)
					{
						Debug.Print("Operation Canceled");
					}
				});
	}
    

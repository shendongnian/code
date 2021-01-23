    public static Task ForEachAsync(
			int totalRequestCount,
			Func<Task> asyncProcessor,
			int? maxDegreeOfParallelism = null)
		{
			IEnumerable<Task> tasks;
			if (maxDegreeOfParallelism != null)
			{
				SemaphoreSlim throttler = new SemaphoreSlim(maxDegreeOfParallelism.Value, maxDegreeOfParallelism.Value);
				tasks = Enumerable.Range(0, totalRequestCount).Select(async requestNumber =>
				{
					await throttler.WaitAsync();
					try
					{
						await asyncProcessor().ConfigureAwait(false);
					}
					finally
					{
						throttler.Release();
					}
				});
			}
			else
			{
				tasks = Enumerable.Range(0, totalRequestCount).Select(requestNumber => asyncProcessor());
			}
			return Task.WhenAll(tasks);
		}
 

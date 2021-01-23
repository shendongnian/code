    public static async Task ForEachAsync<T>(
    	this IQueryable<T> enumerable, Func<T, Task> action, CancellationToken cancellationToken) //Now with Func returning Task
    {
    	var asyncEnumerable = (IDbAsyncEnumerable<T>)enumerable;
    	using (var enumerator = asyncEnumerable.GetAsyncEnumerator())
    	{
    		
    		if (await enumerator.MoveNextAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
    		{
    			Task<bool> moveNextTask;
    			do
    			{
    				var current = enumerator.Current;
    				moveNextTask = enumerator.MoveNextAsync(cancellationToken);
    				await action(current); //now with await
    			}
    			while (await moveNextTask.ConfigureAwait(continueOnCapturedContext: false));
    		}
    	}
    }

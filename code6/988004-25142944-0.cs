	var result = false;
    var tasks = new List<Task>();
	var tcs = new TaskCompletionSource<bool>();
	foreach (var item in list)
	{
		var task = Task.Run(() => GetDataFromLongRunningOp(item))
            .ContinueWith(t =>
			{
				if (CheckCondition(t.Result))
				{
					result = true;
					tcs.TrySetResult(true);
				}
			});
		tasks.Add(task);
	}
	
	await Task.WhenAny(tcs.Task, Task.WhenAll(tasks));
	
	return result;

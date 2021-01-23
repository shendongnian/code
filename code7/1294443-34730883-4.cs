	public async Task BusyLoaderAsync(Action doWorkAction)
	{
		using (var tokenSource = new CancellationTokenSource())
		{
			var tasks = new[] { Task.Run(doWorkAction), Task.Delay(1000) };
			var result = Task.WaitAny(tasks);
			if (result == 1)
			{
				loadingPanel.IsLoading = true;
				await tasks[0];
				loadingPanel.IsLoading = false;
			}
		}
	}

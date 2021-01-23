    public static class ProcessUtils
    {
        static Task RunProcessAsync(string fileName)
        {
		var tcs = new TaskCompletionSource<bool>();
		var process = new Process
		{
			StartInfo = { FileName = fileName },
			EnableRaisingEvents = true
		};
	
		process.Exited += (sender, args) =>
		{
			tcs.SetResult(true);
			process.Dispose();
		};
	
		process.Start();
		return tcs.Task;
        }
    }

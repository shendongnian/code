	public static class ProcessExtensions
	{
		public static Task RunProcessAsync(this Process process, string fileName)
		{
			if (process == null)
				throw new ArgumentNullException(nameof(process));
				
			var tcs = new TaskCompletionSource<bool>();
			process.StartInfo = new ProcessStartInfo
			{
				FileName = fileName 
			};
			
			process.EnableRaisingEvents = true
			process.Exited += (sender, args) =>
			{
				tcs.SetResult(true);
				process.Dispose();
			};
	
			process.Start();
			return tcs.Task;
		}
	}

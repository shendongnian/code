    private static IObservable<string> GetFileSource(string path, CancellationTokenSource cts)
    {
		return
			Directory
				.EnumerateFiles(path, "*", SearchOption.AllDirectories)
				.ToObservable()
				.Take(50)
				.TakeWhile(f => !cts.IsCancellationRequested);
    }

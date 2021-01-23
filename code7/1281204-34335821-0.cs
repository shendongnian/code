	private static readonly ConcurrentQueue<FileInfo> _FileCandidates = new ConcurrentQueue<FileInfo>();
	private static void Main(string[] args)
	{
		var watcher = new FileSystemWatcher
		{
			Path = @"R:\TestFolder",
			IncludeSubdirectories = false,
			Filter = "*.*",
		};
		Console.WriteLine("Start watching folder... " + watcher.Path);
		watcher.Created += OnFileCreated;
		watcher.EnableRaisingEvents = true;
		var timer = new Timer
		{
			AutoReset = true,
			Interval = 1000,
		};
		timer.Elapsed += OnTimerElapsed;
		timer.Enabled = true;
		Console.ReadKey();
	}
	static void OnTimerElapsed(object sender, ElapsedEventArgs e)
	{
		FileInfo file;
		var stillInUseFiles = new List<FileInfo>();
		Console.WriteLine("Check for file candidates...");
		while (_FileCandidates.TryDequeue(out file))
		{
			try
			{
				Console.WriteLine("Delete " + file.FullName);
				if (file.Exists)
					file.Delete();
			}
			catch (IOException)
			{
				Console.WriteLine("Could not delete file, try again next time.");
				stillInUseFiles.Add(file);
			}
		}
		foreach (var unhappyFile in stillInUseFiles)
		{
			_FileCandidates.Enqueue(unhappyFile);
		}
	}
	static void OnFileCreated(object sender, FileSystemEventArgs e)
	{
		Console.WriteLine("Found new file candidate " + e.FullPath);
		_FileCandidates.Enqueue(new FileInfo(e.FullPath));
	}

    class FolderCreationWatcher
	{
		private FileSystemWatcher watcher = new FileSystemWatcher();
		private string lastFileName = string.Empty;
		public delegate void OnFolderCreated(object sender, FileSystemEventArgs e);
		public event OnFolderCreated FolderCreated;
		Timer timer = new Timer();
		public FolderCreationWatcher(string dirPath, int timeOut)
		{
			watcher.Path = dirPath;
			watcher.EnableRaisingEvents = true;
			watcher.Created += watcher_Created;
			timer.Interval = timeOut;
			timer.Enabled = false;
			timer.Elapsed += timer_Elapsed;
		}
		void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.NotifyFolderCreated();
		}
		private void watcher_Created(object sender, FileSystemEventArgs e)
		{
			lastFileName = e.Name;
			watcher.Renamed += OnRenamed;
			timer.Enabled = true;
		}
		void OnRenamed(object sender, RenamedEventArgs e)
		{
			if (e.OldName.Equals(lastFileName))
			{
				lastFileName = e.Name;
				this.NotifyFolderCreated();
			}
		}
		private void NotifyFolderCreated()
		{
			if (FolderCreated != null)
				FolderCreated(this, new FileSystemEventArgs(WatcherChangeTypes.Created, watcher.Path, lastFileName));
			timer.Enabled = false;
			watcher.Renamed -= OnRenamed;
		}

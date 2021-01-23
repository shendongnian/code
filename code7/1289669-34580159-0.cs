	public class FileSystemCrawlerSO
	{
		public int NumFolders { get; set; }
		private readonly ConcurrentQueue<DirectoryInfo> folderQueue = new ConcurrentQueue<DirectoryInfo>();
		private readonly ConcurrentBag<Task> tasks = new ConcurrentBag<Task>();
		public void CollectFolders(string path)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			tasks.Add(Task.Run(() => CrawlFolder(directoryInfo)));
			Task taskToWaitFor;
			while (tasks.TryTake(out taskToWaitFor))
				taskToWaitFor.Wait();
		}
		private void CrawlFolder(DirectoryInfo dir)
		{
			try
			{
				DirectoryInfo[] directoryInfos = dir.GetDirectories();
				foreach (DirectoryInfo childInfo in directoryInfos)
				{
                    // here may be dragons using enumeration variable as closure!!
					DirectoryInfo di = childInfo;
					tasks.Add(Task.Run(() => CrawlFolder(di)));
				}
				// Do something with the current folder
				// e.g. Console.WriteLine($"{dir.FullName}");
				NumFolders++;
			}
			catch(Exception ex)
			{
				while (ex != null)
				{
					Console.WriteLine($"{ex.GetType()} {ex.Message}\n{ex.StackTrace}");
					ex = ex.InnerException;
				}
			}
		}
	}

	using System;
	using System.Collections.Concurrent;
	using System.IO;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	namespace UnitTestProject1
	{
		[TestClass]
		public class UnitTest1
		{
			private ConcurrentQueue<string> _filesProcessQueue;
			private FileSystemWatcher _watcher;
			[TestMethod]
			public void Watch()
			{
				_filesProcessQueue = new ConcurrentQueue<string>();
				_watcher = new FileSystemWatcher
				{
					NotifyFilter = NotifyFilters.LastAccess |
								   NotifyFilters.LastWrite |
								   NotifyFilters.FileName |
								   NotifyFilters.DirectoryName
				};
				_watcher.Created += OnCreated;
			}
			private void OnCreated(object sender, FileSystemEventArgs e)
			{
				// Create a task for reading the file after the lock is released
				Task.Run(() => ProcessFileQueue(e.FullPath));
			}
			private void ProcessFileQueue(string fullPath)
			{
				bool processSuccess = false;
				// TODO put terminator logic in here to stop retrying forever
				while (processSuccess == false)
				{
					// TODO try process the file and return success/fail
					processSuccess = true; // Continue to next file
					//processSuccess = false; // Retry the same file
					Task.Delay(TimeSpan.FromSeconds(5)); // Delay 5 seconds before retrying the file.
				}
			}
		}
	}

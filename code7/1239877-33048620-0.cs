    using System;
    using System.IO;
    using System.Threading;
    using System.Collections.Generic;
    
    namespace FileSystemWatcherExample {
    	class Program {
    		static void Main(string[] args) {
    			// If a directory and filter are not specified, exit program
    			if (args.Length !=2) {
    				// Display the proper way to call the program
    				Console.WriteLine("Usage: Watcher.exe \"directory\" \"filter\"");
    				return;
    			}
    
    			FileProcessor fileProcessor = new FileProcessor();
    
    			// Create a new FileSystemWatcher
    			FileSystemWatcher fileSystemWatcher1 = new FileSystemWatcher();
    
    			// Set FileSystemWatcher's properties
    			fileSystemWatcher1.Path = args[0];
    			fileSystemWatcher1.Filter = args[1];
    			fileSystemWatcher1.IncludeSubdirectories = false;
    
    			// Add event handlers
    			fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
    
    			// Start to watch
    			fileSystemWatcher1.EnableRaisingEvents = true;
    
    			// Wait for the user to quit the program
    			Console.WriteLine("Press \'q\' to quit the program.");
    			while(Console.Read()!='q');
    			
    			// Turn off FileSystemWatcher
    			if (fileSystemWatcher1 != null) {
    				fileSystemWatcher1.EnableRaisingEvents = false;
    				fileSystemWatcher1.Dispose();
    				fileSystemWatcher1 = null;
    			}
    
    			// Dispose fileProcessor
    			if (fileProcessor != null)
    				fileProcessor.Dispose();
    		}
    
    		// Define the event handler
    		private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e) {
    			// If file is created...
    			if (e.ChangeType == WatcherChangeTypes.Created) {
    				// ...enqueue it's file name so it can be processed...
    				fileProcessor.EnqueueFileName(e.FullPath);
    			}
    			// ...and immediately finish event handler
    		}
    	}
    
    
    	// File processor class
    	class FileProcessor : IDisposable {
    		// Create an AutoResetEvent EventWaitHandle
    		private EventWaitHandle eventWaitHandle = new AutoResetEvent(false);
    		private Thread worker;
    		private readonly object locker = new object();
    		private Queue<string> fileNamesQueue = new Queue<string>();
    
    		public FileProcessor() {
    			// Create worker thread
    			worker = new Thread(Work);
    			// Start worker thread
    			worker.Start();
    		}
    
    		public void EnqueueFileName(string FileName) {
    			// Enqueue the file name
    			// This statement is secured by lock to prevent other thread to mess with queue while enqueuing file name
    			lock (locker) fileNamesQueue.Enqueue(FileName);
    			// Signal worker that file name is enqueued and that it can be processed
    			eventWaitHandle.Set();
    		}
    
    		private void Work() {
    			while (true) {
    				string fileName = null;
    
    				// Dequeue the file name
    				lock (locker)
    					if (fileNamesQueue.Count > 0) {
    						fileName = fileNamesQueue.Dequeue();
    						// If file name is null then stop worker thread
    						if (fileName == null) return;
    					}
    
    				if (fileName != null) {
    					// Process file
    					ProcessFile(fileName);
    				} else {
    					// No more file names - wait for a signal
    					eventWaitHandle.WaitOne();
    				}
    			}
    		}
    		
    		private ProcessFile(string FileName) {
    			// Maybe it has to wait for file to stop being used by process that created it before it can continue
    			// Unzip file
    			// Read its content
    			// Log file data to database
    			// Move file to archive folder
    		}
    
    
    		#region IDisposable Members
    
    		public void Dispose() {
    			// Signal the FileProcessor to exit
    			EnqueueFileName(null);
    			// Wait for the FileProcessor's thread to finish
    			worker.Join();
    			// Release any OS resources
    			eventWaitHandle.Close();
    		}
    
    		#endregion
    	}
    }

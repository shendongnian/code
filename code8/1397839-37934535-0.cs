	class FantasticFileService:IDisposable
	{
		private FileSystemWatcher fileWatch; // FileSystemWatcher is IDisposable
		private bool disposed;
		public FantasticFileService(string path)
		{
			fileWatch = new FileSystemWatcher(path);
			fileWatch.Changed += OnFileChanged;
		}
		private void OnFileChanged(object sender, FileSystemEventArgs e)
		{
			// blah blah
		}
		// Public implementation of Dispose pattern callable by consumers.
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		// Protected implementation of Dispose pattern.
		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;
			if (disposing)
			{
				if (fileWatch != null)
				{
					fileWatch.Dispose();
					fileWatch = null;					
				}
				// Free any other managed objects here.
				//
			}
			// Free any unmanaged objects here.
			//
			disposed = true;
		}
        ~FantasticFileService()
        {
            Dispose(false);
        }
	}

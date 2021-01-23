      class FantasticFileService : IDisposable
      {
        private FileSystemWatcher fileWatch; // FileSystemWatcher is IDisposable
    
        public FantasticFileService(string watch)
        {
          fileWatch = new FileSystemWatcher(watch);
          fileWatch.Changed += OnFileChanged;
        }
        ~FantasticFileService()
        {
          Dispose(false);
        }
    
        protected virtual void Dispose(bool disposing)
        {
          if (disposing && fileWatch != null)
          {
            fileWatch.Dispose();
            fileWatch = null;
          }
        }
        public void Dispose()
        {
          Dispose(true);
          GC.SuppressFinalize(this);
        }
      }

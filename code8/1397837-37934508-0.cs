      class FantasticFileService : IDisposable
      {
        private FileSystemWatcher fileWatch; // FileSystemWatcher is IDisposable
    
        public FantasticFileService(string watch)
        {
          fileWatch = new FileSystemWatcher(watch);
          fileWatch.Changed += OnFileChanged;
        }
    
        protected virtual void Dispose(bool disposing)
        {
          if (disposing)
          {
            fileWatch.Dispose();
          }
        }
        public void Dispose()
        {
          Dispose(true);
          GC.SuppressFinalize(this);
        }
      }

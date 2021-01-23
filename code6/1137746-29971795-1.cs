    public class SynchronizedXMLAccess : IDisposable
    {
        private static readonly Mutex _access = new Mutex();
        public FileStream Fs { get; private set; }
        public SynchronizedXMLAccess(String path, FileMode mode = FileMode.Open, FileAccess access = FileAccess.ReadWrite, FileShare sharing = FileShare.None)
        {
            _access.WaitOne();
            Fs = File.Open(path, mode, access, sharing);
        }
        #region Implementation of IDisposable
        public void Dispose()
        {
            Fs.Close();
            _access.ReleaseMutex();
        }
        #endregion
    }

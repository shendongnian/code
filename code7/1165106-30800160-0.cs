    public class FileAcessSynchronizer
    {
        private readonly string _path;
        private readonly EventWaitHandle _waitHandle;
        public FileAcessSynch(string path)
        {
            _path = path;
            _waitHandle =  new EventWaitHandle(true, EventResetMode.AutoReset, Guid.NewGuid().ToString("N"));
        }
        public void DoSomething()
        {
            _waitHandle.WaitOne();
             //do what you want
            _waitHandle.Set();
        }
    }

    public class FileAcessSynchronizer
    {
        private readonly string _path;
        private readonly EventWaitHandle _waitHandle;
        public FileAcessSynch(string path)
        {
            _path = path;
            _waitHandle =  new EventWaitHandle(true, EventResetMode.AutoReset, "NameOfTheWaitHandle");
        }
        public void DoSomething()
        {
            _waitHandle.WaitOne();
            using (FileStream filestream = new FileStream(chosenFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            using (StreamReader sr = new StreamReader(filestream))
            using (StreamWriter sw = new StreamWriter(filestream))
            {
                //reading and writing to file
            }
            _waitHandle.Set();
        }
    }

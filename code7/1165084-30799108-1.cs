    public class IncrementalNumberGenerator
    {
        private readonly string _path;
        private readonly EventWaitHandle _waitHandle; 
        public IncrementalNumberGenerator(string path)
        {
            _path = path;
            _waitHandle =  new EventWaitHandle(true, EventResetMode.AutoReset, Guid.NewGuid().ToString("N"));
            if (!File.Exists(_path))
                File.WriteAllText(_path,"0");
        }
        public ulong Next()
        {
            _waitHandle.WaitOne();
            var currentValue = ulong.Parse(File.ReadAllText(_path));
            File.WriteAllText(_path, (currentValue + 1).ToString());
            _waitHandle.Set();
            return currentValue + 1;
        }
    }

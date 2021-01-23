    public class PersistantQueue
    {
        private string _FolderPath = "";
        private long _FileIdCounter = 0;
        private readonly object _LockObject = new object();
                
        public PersistantQueue()
        {
            Init("PersistantList");
        }
    
        public PersistantQueue(string folderPath)
        {
            Init(folderPath);
        }
    
        private void Init(string folderPath)
        {
            _FolderPath = folderPath;
    
            if (string.IsNullOrWhiteSpace(folderPath.Trim()) == true)
                throw new Exception("Invalid folder name");
    
            if (Directory.Exists(_FolderPath) == false)
                Directory.CreateDirectory(_FolderPath);
        }
    
        public void Add(string Item)
        {
            lock (_LockObject)
            {
                _FileIdCounter++;
    
                string file = DateTime.Now.ToString("yyyyMMddhhmmssfff") + "_" + _FileIdCounter;
                string path = (_FolderPath + @"\" + file);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(Item);
                }
            }
        }
    
        public string GetNext()
        {
            string result = null;
            lock (_LockObject)
            {
                DirectoryInfo di = new DirectoryInfo(_FolderPath);
    
                var firstFileName = di.EnumerateFiles()
                            .Select(f => f.Name)
                            .FirstOrDefault();
    
                string path = (_FolderPath + @"\" + firstFileName);
                result = File.ReadAllText(path);
                File.Delete(path);
            }
            return result;
        }
    }

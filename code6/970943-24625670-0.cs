    public class TaskInfo
    {
        private readonly string _hostName;
        public string HostName
        {
            get { return _hostName; }
        }
        private readonly ReadOnlyCollection<string> _files;
        public ReadOnlyCollection<string> Files
        {
            get { return _files; }
        }
        public TaskInfo(string host, IEnumerable<string> files)
        {
            _hostName = host;
            _files = new ReadOnlyCollection<string>(files.ToList());
        }
    }

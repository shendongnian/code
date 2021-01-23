    private Dictionary<string, FileSystemWatcher> _fileSystemWatcherMap;
    public MainForm()
    {
        InitializeComponent();
        _fileSystemWatcherMap = new Dictionary<string, FileSystemWatcher>();
    }
    public void Button1Click(object sender, EventArgs e)
    {
        string pathToWatch = @"C:\"; // Must be a different path each time otherwise will throw
        var watcher = new FileSystemWatcher(pathToWatch);
        _fileSystemWatcherMap.Add(pathToWatch, watcher);
    }

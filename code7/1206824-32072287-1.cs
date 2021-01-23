    public Form1()
    {
        InitializeComponent();
        fileSystemWatcher1.Changed += new FileSystemEventHandler(OnChanged);
    }

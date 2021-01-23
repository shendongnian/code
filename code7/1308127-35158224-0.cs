    // Keeps track of the last file number with this global variable
    private int fileCount;
    public void OnDebug()
    {
        OnStart(null);
    }
    protected override void OnStart(string[] args)
    {
        fileCount = 0; // Or whatever you want to start with
        Timer t = new Timer(WriteTxt, null, 0, 5000);
    }
    public static void WriteTxt(Object i)
    {
        // Creates the file name eg: OnStart1.txt
        var fileName = string.Format("OnStart{0}.txt", fileCount);
        // Use Path.Combine to make paths
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        
        // Create the file
        File.Create(filePath).Dispose();
        // Adds 1 to the value
        fileCount++;
    }

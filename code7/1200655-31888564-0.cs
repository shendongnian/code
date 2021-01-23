    // The default backing collection for BlockingCollection<T>
    // is ConcurrentQueue<T>. There's no need to specify that
    // explicitly.
    public static BlockingCollection<string> processCollection = new BlockingCollection<string>();
    static void Main(string[] args)
    {
        string testDirectory = Path.Combine(Environment.CurrentDirectory, "test");
        Console.WriteLine("Creating directory: \"{0}\"", testDirectory);
        Directory.CreateDirectory(testDirectory);
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = testDirectory;
        watcher.EnableRaisingEvents = true;
        watcher.Filter = "*.*";
        watcher.Created += new FileSystemEventHandler(onCreated);
        Thread Consumer = new Thread(new ParameterizedThreadStart(mover));
        Consumer.Start(testDirectory);
        string text;
        while ((text = Console.ReadLine()) != "")
        {
            string newFile = Path.Combine(testDirectory, text + ".txt");
            File.WriteAllText(newFile, "Test file");
        }
        processCollection.CompleteAdding();
    }
    static void onCreated(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Created)
        {
            processCollection.Add(e.FullPath);
        }
    }
    static void mover(object testDirectory)
    {
        string processed = Path.Combine((string)testDirectory, "processed");
        Console.WriteLine("Creating directory: \"{0}\"", processed);
        Directory.CreateDirectory(processed);
        foreach (string current in processCollection.GetConsumingEnumerable())
        {
            // Ensure that the file is in fact a file and not something else.
            if (File.Exists(current))
            {
                System.IO.File.Move(current, Path.Combine(processed, Path.GetFileName(current)));
            }
        }
    }

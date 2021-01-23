    static void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("File Created: Path: {0}, \n Name: {1}", e.FullPath, e.Name);
        CreatedQueue.Add(e.FullPath);
    }

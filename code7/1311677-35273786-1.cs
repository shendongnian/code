    public static void ProcessDirectory(string targetDirectory)
    {
        ProcessDirectory(targetDirectory, targetDirectory);
    }   
        
    public static void ProcessDirectory(string targetDirectory, string pathToRemove)
    {
        // Process the list of files
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        Parallel.ForEach(fileEntries, fileEntry =>
        {
             ProcessFile(fileEntry, pathToRemove);
        });
        // Recurse into subdirectories
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        Parallel.ForEach(subdirectoryEntries, subdirectoryEntry =>
        {
            ProcessDirectory(subdirectoryEntry, pathToRemove);
        });
    }
    public static void ProcessFile(string path, string pathToRemove)
    {
        Console.WriteLine(path.Replace(pathToRemove,""));
    }

    public static void ProcessDirectory(string targetDirectory) 
    {
        // Process the list of files found in the directory.
        string [] fileEntries = Directory.GetFiles(targetDirectory);
        foreach(string fileName in fileEntries)
            ProcessFile(fileName);
    
        // Recurse into subdirectories of this directory.
        string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach(string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory);
    }
    
    // Insert logic for processing found files here.
    public static void ProcessFile(string path) 
    {
        Console.WriteLine("Processed file '{0}'.", path);	    
    }

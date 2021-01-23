    public static void processDirectory(string startLocation)
    {
        foreach (var directory in Directory.GetDirectories(startLocation))
        {
            processDirectory(directory);
            var aFiles = Directory.GetFiles(directory);
            var noFiles = aFiles.Length == 0 || (aFiles.Length == 1 && aFiles.Count(file => Path.GetExtension(file) == ".txt") == 1);
            if (noFiles && Directory.GetDirectories(directory).Length == 0)
            {
                Directory.Delete(directory, true);
            }
        }           
    }

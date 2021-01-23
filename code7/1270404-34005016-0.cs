    public static void processDirectory(string startLocation)
    {
        foreach (var directory in Directory.GetDirectories(startLocation))
        {
            processDirectory(directory);
            var aFiles = Directory.GetFiles(directory);
            var noFiles = aFiles.Length == 0 || aFiles.Any(file => Path.GetExtension(file) == ".txt");
            if (noFiles && Directory.GetDirectories(directory).Length == 0)
            {
                Directory.Delete(directory, false);
            }
        }           
    }

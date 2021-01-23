    List<string> missingDirectories = null;
    private void MakeParents(string path)
    {
        missingDirectories = new List<string>();
        missingDirectories.Add(path);
        parentDir(path);
        missingDirectories = missingDirectories.OrderBy(x => x.Length).ToList<string>();
        foreach (string directory in missingDirectories)
        {
            Directory.CreateDirectory(directory);
        }        
    }
    private void parentDir(string path)
    {
        string newPath = path.Substring(0, path.LastIndexOf(Path.DirectorySeparatorChar));
        if (!Directory.Exists(newPath))
        {
            missingDirectories.Add(newPath);
            parentDir(newPath);
        }
    }

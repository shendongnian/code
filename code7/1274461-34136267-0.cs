    public void CopyRecursive(string path, string newLocation)
    {
        foreach(var file in DirectoryInfo.GetFiles(path))
        {
            File.Copy(file.FullName, newLocation + file.Name);
        }
        foreach(var dir in DirectoryInfo.GetDirectories(path))
        {
            CopyRecursive(path + dir.Name, newLocation);
        }
    }

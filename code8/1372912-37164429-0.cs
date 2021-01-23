    void CopyAppFiles(string SourcePath, string )
    {
        foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
        }
    
        foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
        {
            File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
        }
    }

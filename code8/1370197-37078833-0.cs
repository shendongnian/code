    public void DeleteFiles(DirectoryInfo di, string searchPattern)
    {
        foreach (FileInfo file in di.GetFiles(searchPattern))
        {
            file.Delete();
        }
    }

    static List<string> FolderList = new List<string>();
    static void Selection(DirectoryInfo dir)
    {
        var dirs = dir.GetDirectories("*", SearchOption.AllDirectories);
        foreach (var a_dir in dirs)
        {
            FolderList.Add(dir.FullName);
        }
    }

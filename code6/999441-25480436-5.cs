    public enum MergeDirectoryNameOption
    {
        MergeNon = 0,
        MergeAllButRoot = 1,
        MergeDirAndFile = 2
    }
    public static bool IsFileInSubDirectoryOf(string filePath, string directory)
    {
        var dir1 = new DirectoryInfo(directory);
        if (!dir1.Exists || !File.Exists(filePath))
            return false;
        var dir2 = new DirectoryInfo(Path.GetDirectoryName(filePath));
        if (dir2.FullName == dir1.FullName) return true;
        while (dir2.Parent != null)
        {
            if (dir2.Parent.FullName == dir1.FullName)
                return true;
            else
                dir2 = dir2.Parent;
        }
        return false;
    }

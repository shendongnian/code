    static void Copy(string sourcePath, string targetPath)
    {
        Directory.CreateDirectory(targetPath);
        var files = Directory.EnumerateFiles(sourcePath, "*.*", SearchOption.AllDirectories)
            .Where(fn => !IsSubDirectory(targetPath, fn));
        foreach (string srcPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
        {
            string oldPath = string.Join("_", srcPath.Split(Path.DirectorySeparatorChar).Skip(1));
            string newPath = Path.Combine(targetPath, oldPath);
            File.Copy(srcPath, newPath, true);
        }
    }
    static bool IsSubDirectory(string folder, string filePath)
    {
        var dir1 = new DirectoryInfo(folder);
        if (!dir1.Exists || !File.Exists(filePath))
            return false;
        var dir2 = new DirectoryInfo(Path.GetDirectoryName(filePath));
        while (dir1.Parent != null)
        {
            if (dir2.Parent.FullName == dir1.FullName)
            {
                return true;
            }
            else dir2 = dir2.Parent;
        }
        return false;
    }

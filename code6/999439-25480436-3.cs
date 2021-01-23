    public enum MergeDirectoryNameOption
    {
        MergeNon = 0,
        MergeAllButRoot = 1,
        MergeDirAndFile = 2
    }
    public static void Copy(string sourcePath, string targetPath, MergeDirectoryNameOption option = MergeDirectoryNameOption.MergeDirAndFile, string mergeDelimiter = "_")
    {
        Directory.CreateDirectory(targetPath);
        var files = Directory.EnumerateFiles(sourcePath, "*.*", SearchOption.AllDirectories)
            .Where(filePath => !IsFileInSubDirectoryOf(filePath, targetPath));
        foreach (string srcPath in files)
        {
            string newFilePath = null;
            switch (option)
            {
                case MergeDirectoryNameOption.MergeNon:
                    newFilePath = Path.GetFileName(srcPath);
                    break;
                case MergeDirectoryNameOption.MergeAllButRoot:
                    string[] allDirs = srcPath.Split(Path.DirectorySeparatorChar);
                    newFilePath = string.Join(mergeDelimiter, allDirs.Skip(1));
                    break;
                case MergeDirectoryNameOption.MergeDirAndFile:
                    string[] allDirsButLast = Path.GetDirectoryName(srcPath).Split(Path.DirectorySeparatorChar);
                    newFilePath = string.Join(Path.DirectorySeparatorChar.ToString(), allDirsButLast.Skip(1));
                    newFilePath = newFilePath + mergeDelimiter + Path.GetFileName(srcPath);
                    break;
                default:
                    throw new NotSupportedException(string.Format("MergeDirectoryNameOption '{0}' is not supported.", option));
            }
            string newPath = Path.Combine(targetPath, newFilePath);
            Directory.CreateDirectory(Path.GetDirectoryName(newPath));
            File.Copy(srcPath, newPath, true);
        }
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

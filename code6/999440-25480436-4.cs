    public static void Copy(string sourcePath, string targetPath, MergeDirectoryNameOption option = MergeDirectoryNameOption.MergeDirAndFile, string mergeDelimiter = "_")
    {
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

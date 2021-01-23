    public static void MoveDirectory(string source, string target)
    {
        var delSourceAtEnd = true;
        var sourcePath = source.TrimEnd('\\', ' ');
        var targetPath = target.TrimEnd('\\', ' ');
        var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                .GroupBy(Path.GetDirectoryName);
        foreach (var folder in files)
        {
            var failed = false;
            var targetFolder = folder.Key.Replace(sourcePath, targetPath);
            Directory.CreateDirectory(targetFolder);
            foreach (var file in folder)
            {
                var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                try
                {
                    File.Move(file, targetFile);
                } catch (UnauthorizedAccessException uae)
                {
                    failed = true;
                    delSourceAtEnd = false;
                }
            }
            if (!failed) Directory.Delete(folder.Key);
        }
        if (delSourceAtEnd) Directory.Delete(source, false);
    }

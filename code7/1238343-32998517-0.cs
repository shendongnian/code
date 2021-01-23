    var directory = new DirectoryInfo(targetDir);
    if (directory.Exists)
    {
        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(targetDir, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
    }

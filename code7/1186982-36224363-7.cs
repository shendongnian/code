    private void CopyFiles()
    {
        var folder = Path.GetDirectoryName(SelectedItemPaths.First());
        var newFolder = Path.Combine(folder, "New Folder");
        Directory.CreateDirectory(newFolder);
        foreach (var path in SelectedItemPaths)
        {
            var newPath = Path.Combine(newFolder, Path.GetFileName(path));
            File.Move(path, newPath);
        }
        RenameInExplorer(newFolder);
    }
    private static void RenameInExplorer(string itemPath)
    {
        IntPtr folder = Win32.ILCreateFromPath(Path.GetDirectoryName(itemPath));
        IntPtr file = Win32.ILCreateFromPath(itemPath);
        try
        {
            Win32.SHOpenFolderAndSelectItems(folder, 1, new[] { file }, 1);
        }
        finally
        {
            Win32.ILFree(folder);
            Win32.ILFree(file);
        }
    }

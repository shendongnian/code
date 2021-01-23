    string[] supportedExtensions = new[] { ".mov", ".mp4", ".avi", ".mpeg", ".mpg", ".wmv", ".mkv", ".m4v", ".flv" };
    var allFiles = Directory.GetFiles(SelectedFolderPath, "*.*", SearchOption.TopDirectoryOnly).Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower()));
    foreach (string name in allFiles)
    {
       Shell shell = new Shell();
       Folder rFolder = shell.NameSpace(@SelectedFolderPath);
       FolderItem rFiles = rFolder.ParseName(System.IO.Path.GetFileName(name));
       string videosLength = rFolder.GetDetailsOf(rFiles, 27).Trim();
    }

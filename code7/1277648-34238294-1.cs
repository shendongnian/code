    public IFileInfo GetFileInfo(string subpath)
    {
         if (string.IsNullOrEmpty(subpath))
         {
             return new NotFoundFileInfo(subpath);
         }
    
         // Relative paths starting with a leading slash okay
         if (subpath.StartsWith("/", StringComparison.Ordinal))
         {
             subpath = subpath.Substring(1);
         }
    
         // Absolute paths not permitted.
         if (Path.IsPathRooted(subpath))
         {
             return new NotFoundFileInfo(subpath);
         }
    
         var fullPath = GetFullPath(subpath);
         if (fullPath == null)
         {
             return new NotFoundFileInfo(subpath);
         }
    
         var fileInfo = new FileInfo(fullPath);
         if (FileSystemInfoHelper.IsHiddenFile(fileInfo))
         {
             return new NotFoundFileInfo(subpath);
         }
    
         return new PhysicalFileInfo(_filesWatcher, fileInfo);
    }
    private string GetFullPath(string path)
    {
        var fullPath = Path.GetFullPath(Path.Combine(Root, path));
        if (!IsUnderneathRoot(fullPath))
        {
            return null;
        }
        return fullPath;
    }

    private static List<string> mContentFilenames = new List<string>();
    private static void preloadContentFilenamesRecursive(StorageFolder sf)
    {
        var files = sf.GetFilesAsync().AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
        if (files != null)
        {
            foreach (var f in files)
            {
                mContentFilenames.Add(f.Path.Replace('\\','/'));
            }
        }
        var folders = sf.GetFoldersAsync().AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
        if (folders != null)
        {
            foreach (var f in folders)
            {
                preloadContentFilenamesRecursive(f);
            }
        }
    }
    private static void preloadContentFilenames()
    {
        if (mContentFilenames.Count > 0)
            return;
        var installed_loc = Windows.ApplicationModel.Package.Current.InstalledLocation;
        var content_folder = installed_loc.GetFolderAsync("Content").AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
        if (content_folder != null)
            preloadContentFilenamesRecursive(content_folder);
    }
    private static bool searchContentFilename(string name)
    {
        var v = from val in mContentFilenames where val.EndsWith(name.Replace('\\', '/')) select val;
        return v.Any();
    }

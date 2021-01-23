    private static void SPCreateFolder(SPWeb web, string filepath)
    {
        // since you pass this as Path.GetDictionary it's no longer split by '/'
        var foldersTree = filepath.Split('\\');
        foldersTree.Aggregate(web.RootFolder, GetOrCreateSPFolder);
    }
    
    private static SPFolder GetOrCreateSPFolder(SPFolder sourceFolder, string folderName)
    {
        SPFolder destination;
    
        try
        {
    		// return the existing SPFolder destination if already exists
    		destination = sourceFolder.SubFolders[folderName];
        }
        catch
        {
    		// Create the folder if it can't be found
    		destination = sourceFolder.SubFolders.Add(folderName);
        }
    
        return destination;
    }

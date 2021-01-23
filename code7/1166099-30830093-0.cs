    public readonly object syncRoot = new object();
    lock (syncRoot)
    {
        if (!ExistingFolders.Contains(currentFolder))
        {
            if (lastCreatedFolder != folder) 
            {
                lastCreatedFolder = folder;
                CreateNewFolder(context, siteLink, lName, fName);
            }
        }
    }

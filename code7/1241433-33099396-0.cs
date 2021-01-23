    public static Folder CreateFolder(Web web, string listTitle, string fullFolderUrl)
    {
        if (string.IsNullOrEmpty(fullFolderUrl))
            throw new ArgumentNullException("fullFolderUrl");
        var list = web.Lists.GetByTitle(listTitle);
        clientContext.Load(list);
        clientCOntext.Execute();
        return CreateFolderInternal(web, list.RootFolder, fullFolderUrl);
    }

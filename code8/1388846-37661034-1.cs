    public Dictionary<string, string> LoadDocuments(IEnumerable<string> folderUrls)
    {
        if (!folderUrls.Any()
            return new Dictionary<string, string>();
        var feeds = folderUrls
            .Select(url => url.GetResponse(headerToken)
                              .GetXmlString()
                              .DeserializeFromXml<Library.Children.Feed>())
            .SelectMany(x => x.Entries);
        
        var nestedFolders = feeds
            .Where(entry => entry.Content.ContentContainsFolderUrl(type: "Folder"))
            .Select(x => $"{x.Link.Href}/children");
        
        // Recursive call to load nested documents.    
        var nestedDocuments = LoadDocuments(nestedFolders);
        
        var documents = feeds
            .Where(entry => entry.Content.ContentContainsFolderUrl(type: "webi"));
            
        return documents
            .ToDictionary(
                x => x.Content.Attrs.Attr
                      .Where(y => y.Name.ToLower() == "id")
                      .First().Text,
                x => x.Content.Attrs.Attr
                      .Where(y => y.Name.ToLower() == "name")
                      .First().Text)
            .Concat(nestedDocuments)
            .ToDictionary(x => x.Key, x => x.Value);
    }

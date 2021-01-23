    // I don't know what the type of "entry" is. Replace "TEntry" with the correct type.
    public IEnumerable<TEntry> LoadDocuments(IEnumerable<TEntry> feedEntries)
    {
        var folderUrls = feedEntries
            .Where(entry => entry.Content.ContentContainsFolderUrl(type: "folder"))
            .Select(entry => $"{entry.Link.Href}/children");
        if (!folderUrls.Any())
            return Enumerable.Empty<TEntry>();
        var feeds = folderUrls
            .Select(url => url.GetResponse(headerToken)
                              .GetXmlString()
                              .DeserializeFromXml<Library.Children.Feed>())
            .SelectMany(x => x.Entries)
            .ToList();
        // Recursive call to load nested documents.    
        var nestedDocuments = LoadDocuments(feeds);
        var documents = feeds
            // What's the type of "entry" here? Use that type for the return type of this 
            // function.
            .Where(entry => entry.Content.ContentContainsFolderUrl(type: "webi"));
        return documents.Concat(nestedDocuments);
    }

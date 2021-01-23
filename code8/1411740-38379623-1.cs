    var returnList = new List<ContentBase>();
    returnList.Add(new ContentBase()
    {
        // Initialize properties the same way you are setting them
        // Including the images property this way:
        images = htmlDocument.DocumentNode.SelectNodes("//img")
                             .Select(x=>x.Attributes["src"].Value).ToArray();
    });
    

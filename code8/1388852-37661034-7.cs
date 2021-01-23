    var rootFeed = $"{baseUrl}/biprws/infostore/{23}/children"
        .Do(str => Console.WriteLine($"{str}:"))
        .GetResponse(headerToken)
        .GetXmlString()
        .DeserializeFromXml<Library.Children.Feed>();
    var folderUrls = rootFeed.Entries
        .Where(entry => entry.Content.ContentContainsFolderUrl(type: "folder"))
        .Select(entry => $"{entry.Link.Href}/children");
    var documentUrls = LoadDocuments(folderUrls)
        .ToDictionary(
            x => x.Content.Attrs.Attr
                  .Where(y => y.Name.ToLower() == "id")
                  .First().Text,
            x => x.Content.Attrs.Attr
                  .Where(y => y.Name.ToLower() == "name")
                  .First().Text);

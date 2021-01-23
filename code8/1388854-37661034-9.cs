    var rootFeed = $"{baseUrl}/biprws/infostore/{23}/children"
        .Do(str => Console.WriteLine($"{str}:"))
        .GetResponse(headerToken)
        .GetXmlString()
        .DeserializeFromXml<Library.Children.Feed>();
    var documentUrls = LoadDocuments(rootFeed.Entries)
        .ToDictionary(
            x => x.Content.Attrs.Attr
                  .Where(y => y.Name.ToLower() == "id")
                  .First().Text,
            x => x.Content.Attrs.Attr
                  .Where(y => y.Name.ToLower() == "name")
                  .First().Text);

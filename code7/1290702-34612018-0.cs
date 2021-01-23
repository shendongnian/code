    var xdoc = XDocument.Load(@"mypath");
    var paths = xdoc.Descendants("playlist")
                    .SelectMany(x => x.Descendants("media"), (pl, media) => Tuple.Create(pl.Attribute("name").Value, media.Attribute("path").Value))
                    .GroupBy(x => x.Item1)
                    .ToList();
    foreach (var name in paths.Where(x => x.Key == "Films"))
    {
        Console.WriteLine(name.Key);
        foreach (var tuple in name)
        {
            Console.WriteLine(tuple.Item2);
        }
    }

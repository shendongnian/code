    var userInfos = XDocument.Load(filename)
            .Descendants("userInfo")
            .Select(d => d.Elements().ToDictionary(e => e.Name.LocalName, e => (string)e))
            .ToList();
    foreach (var ui in userInfos)
    {
        foreach (var item in ui)
        {
            Console.WriteLine(item.Key + " > " + item.Value);
        }
        Console.WriteLine();
    }

    var names = new XName[] { "a", "b", "c", "d" };
    foreach (XElement xItem in xmlDoc.Root.Elements("item"))
    {
        var element = xItem.Elements().FirstOrDefault(x => names.Contains(x.Name));
        //Do something with element
    }

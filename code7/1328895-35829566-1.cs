    using (var stream = new MemoryStream(Encoding.Default.GetBytes(xml)))
    {
        var xdoc = XDocument.Load(stream);
        var id = xdoc
            .Root
            .Elements("key")
            .First(element =>
                element.Value == "Id")
            .ElementsAfterSelf("string")
            .First()
            .Value;
        Console.WriteLine("The id from XDocument is {0}", id);
    }

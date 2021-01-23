    var elem = XElement.Parse(File.ReadAllText(@"D:\Temp\text.txt"));
    RemoveNamespaces(elem);
    using (var writer = XmlWriter.Create(@"D:\Temp\text.txt", new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = true,
        }))
    {
        elem.WriteTo(writer);
    }

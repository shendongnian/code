    var elements = from user in userResults
                   select new XElement("user",
                        new XElement("id", user.Id),
                   .....<snip>...... );
    
    var content = new XStreamingElement("users", elements);
    
    using (var output = _fileSystemWrapper.CreateText(destinationXmlFileName))
    using (var writer = XmlWriter.Create(output, new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true })
    {
        // Use the next line if you don't require standalone="yes" attribute
        // content.Save(writer);
        writer.WriteStartDocument(true);
        content.WriteTo(writer);
        writer.WriteEndDocument();
    }

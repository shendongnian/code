    var output = new StringBuilder();
    var writerSettings = new XmlWriterSettings { /* your settings ... */ };
    using (var xmlWriter = XmlWriter.Create(output, writerSettings))
    {
        // Your xml generation code using the writer
        // ...
        // You don't need to flush the writer, it will be done automatically
    }
    // Here the output variable contains the xml, let's take it...
    var xml = output.ToString();
    // write it to a file...
    File.WriteAllText(filePath, xml);
    // and we are done :-)
    return xml;

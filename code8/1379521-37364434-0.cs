    var items = new List<string> {"Test1", "Test2"};
    var attachments = items.Select((value, index) =>
        new XElement("Attachment", new XAttribute("INDEX" + index, value)));
    var doc = XDocument.Load(@"path/to/file.xml");
        
    doc.Descendants("Attachments")
        .Single()
        .Add(attachments);

    var commands = new Dictionary<DateTime, string>();
    XDocument xDoc = XDocument.Load("filename.xml");            
    foreach (XElement xCommand in xDoc.Root.Elements())
    {
        commands.Add(
            DateTime.Parse(xCommand.Element("TimeStamp").Value, CultureInfo.CurrentCulture),
            xCommand.Element("FullCommand").Value);
    }

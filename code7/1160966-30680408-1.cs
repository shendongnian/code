    string path = @"D:\web.config";
    string fileContents = string.Empty;
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.IgnoreComments = true;
    using (XmlReader reader = XmlReader.Create(path, settings))
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.PreserveWhitespace = true;
        xDoc.Load(reader);
        fileContents = xDoc.InnerXml;    
    }
    System.IO.File.WriteAllText(path, fileContents);

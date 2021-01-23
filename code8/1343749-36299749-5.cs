    public static void SerializeFilesToXml(string directoryPath, string xmlPath)
    {
        var docs = from file in Directory.GetFiles(directoryPath)
                   select new Document { DocumentPath = file };
        var container = new DocumentContainer { DocumentCollection = docs.ToList() };
        using (var stream = File.Open(xmlPath, FileMode.Create, FileAccess.ReadWrite))
        using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true, IndentChars = " " }))
        {
            new XmlSerializer(container.GetType()).Serialize(writer, container);
        }
        Debug.WriteLine("Wrote " + xmlPath);
    }

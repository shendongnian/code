    var settings = new XmlWriterSettings { Indent = true };
    var DCS = new DataContractSerializer(typeof(Entry));
    using (var writer = XmlWriter.Create(fileName, settings)) // with indentation
    {
        writer.WriteStartDocument();
        writer.WriteStartElement("Entries");
        foreach (var entry in Entries)
        {
            DCS.WriteObject(writer, entry);
        }
    }
    using (var reader = XmlReader.Create(fileName))
    {
        while (reader.ReadToFollowing("Entry"))
        {
            var xmlEntry = (Entry)DCS.ReadObject(reader);
            // ...
        }
    }

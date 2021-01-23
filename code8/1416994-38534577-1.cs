    try
    {
        xmlDoc = XDocument.Load(path);
        XElement newXml = new XElement();
        using (var writer = newXml.CreateWriter())
        {
            // write xml into the writer
            XmlSerializer xmlSerialized = new XmlSerializer(typeof(DataClass.Task));
            xmlSerialized.WriteObject(writer, taskStruct);
        }
        
        xmlDoc.Add(writer);
        bSuccess = true;
    }

    try
    {
        xmlDoc = XDocument.Load(path);
        XDocument newXml = new XDocument();
        using (var writer = newXml.CreateWriter())
        {
            // write xml into the writer
            DataContractSerializer xmlSerialized = new DataContractSerializer(typeof(DataClass.Task));
            xmlSerialized.WriteObject(writer, taskStruct);
        }
        
        xmlDoc.Add(writer);
        bSuccess = true;
    }

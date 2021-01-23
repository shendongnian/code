    private void SaveAsXML(MySettings settings, string fileName)
    {
        using (var streamWriter = File.CreateText(fileName))
        {
            var xmlSerializer = new XMLSerializer(typeof(MySettings));
            xmlSerializer.Serialize(streamWriter, settings);
        }
    }
    
    private MySettings ReadAsXML(string fileName)
    {
        using (var streamReader = File.OpenText(fileName))
        {
            var xmlSerializer = new XMLSerializer(typeof(MySettings));
            return xmlSerializer.Deserialize(streamReader);
        }
    }

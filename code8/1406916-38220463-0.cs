    var list = new List<Person>();
    varr xs = new XmlSerializer(typeof(Person));
    using (StreamWriter streamWriter = System.IO.File.CreateText(fileName))
    {
        xmlSerializer.Serialize(streamWriter, list);
    }

    public List<Serialization> XMLDeserialize()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<Serialization>));
        TextReader reader = new StreamReader(xmlPath);
        var XMLDeserialize = (List<Serialization>) deserializer.Deserialize(reader);
        reader.Dispose();
        return XMLDeserialize;
    }

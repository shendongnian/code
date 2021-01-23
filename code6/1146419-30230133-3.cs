    /// <summary>
    /// Load an object from an xml file
    /// </summary>
    /// <param name="FileName">Xml file name</param>
    /// <returns>The object created from the xml file</returns>
    public static [ObjectType] Load(string FileName)
    {
        using (var stream = System.IO.File.OpenRead(FileName))
        {
            var serializer = new XmlSerializer(typeof([ObjectType]));
            return serializer.Deserialize(stream) as [ObjectType];
        }
    }

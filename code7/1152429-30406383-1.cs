    public Data1 Load(string filename)
    {
        if (System.IO.File.Exists(filename))
        {
            using (var stream = System.IO.File.OpenRead(filename))
            {
                var deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return deserializer.Deserialize(stream) as Data1;
            }
        }
        return null;
    }

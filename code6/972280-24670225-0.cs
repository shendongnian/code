    public T Deserialize(string filename)
    {
        // There's no need to make the serializer a property or instance variable...
        var serializer = new XmlSerializer(typeof(T));
        using (var stream = File.OpenRead(filename))
        {
            return (T) serializer.Deserialize(stream);
        }
    }

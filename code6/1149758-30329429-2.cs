    public void Serialize(string path)
    {
        using (var stream = File.Create(path))
        {
            WriteXmlToStream(stream);
        }
    }

    public string ToJson()
    {
        var serializer = new DataContractJsonSerializer(this.GetType());
        using (var stream = new MemoryStream())
        {
            serializer.WriteObject(stream, this);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }

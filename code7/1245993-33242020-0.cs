    using (var stream = new MemoryStream())
    {
        using (var data = new StreamWriter(stream))
        {
            sut.BusinessMethod(dto, data);
        }
        // moved outside of inner using to ensure writer stored content to stream
        string result = Encoding.UTF8.GetString(stream.ToArray());
    }

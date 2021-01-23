    using (var stream = new MemoryStream())
    {
        using (var writer = new StreamWriter(stream))
        {
            sut.BusinessMethod(dto, writer);
        }
        // moved outside of inner using to ensure writer stored content to stream
        string result = Encoding.UTF8.GetString(stream.ToArray());
    }

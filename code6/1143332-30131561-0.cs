    s.Seek(0, SeekOrigin.End);
    using (StreamWriter writer = new StreamWriter(stream))
    {
        await writer.WriteAsync(text);
        await writer.FlushAsync();
    }

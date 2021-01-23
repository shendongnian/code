    public static async Task AppendTextConcurrentAsync(this CloudAppendBlob appendBlob, string content)
    {
        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
        {
            await appendBlob.AppendBlockAsync(stream);
        }
    }

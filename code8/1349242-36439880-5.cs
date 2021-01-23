    app.Use(async (context, next) =>
    {
        if (!IsMultipartContentType(context.Request.ContentType))
        {
            await next();
            return;
        }
        var boundary = GetBoundary(context.Request.ContentType);
        var reader = new MultipartReader(boundary, context.Request.Body);
        var section = await reader.ReadNextSectionAsync();
        const int chunkSize = 1024;
        var buffer = new byte[chunkSize];
        while (section != null)
        {
            int bytesRead;
            using (var stream = new FileStream("fileName", FileMode.Append))
            {
                while (bytesRead = await section.Body.ReadAsync(buffer, 0, buffer.Length) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }
            section = await reader.ReadNextSectionAsync();
        }
    });

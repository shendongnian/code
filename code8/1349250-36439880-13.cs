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
        while (section != null)
        {
            // process each image
            const int chunkSize = 1024;
            var buffer = new byte[chunkSize];
            var bytesRead = 0;
            var fileName = GetFileName(section.ContentDisposition);
            using (var stream = new FileStream(fileName, FileMode.Append))
            {
                do
                {
                    bytesRead = await section.Body.ReadAsync(buffer, 0, buffer.Length);
                    stream.Write(buffer, 0, bytesRead);
    
                } while (bytesRead > 0);
            }
    
            section = await reader.ReadNextSectionAsync();
        }
    
        context.Response.WriteAsync("Done.");
    });

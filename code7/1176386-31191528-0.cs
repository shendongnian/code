    if (!content.IsMimeMultipartContent())
    {
        throw new UnsupportedMediaTypeException("MIME Multipart Content is not supported");
    }
    var uploadPath = **whatever**;
    if (!Directory.Exists(uploadPath))
    {
        Directory.CreateDirectory(uploadPath);
    }
    var provider = new MultipartFormDataStreamProvider(uploadPath);
    await content.ReadAsMultipartAsync(provider);
    return File.ReadAllBytes(provider.FileData[0].LocalFileName);

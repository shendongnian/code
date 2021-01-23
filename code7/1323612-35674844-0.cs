    if (!Request.Content.IsMimeMultipartContent())
        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
    var provider = new MultipartMemoryStreamProvider();
    await Request.Content.ReadAsMultipartAsync(provider);
    var fileNames = new List<string>();
    foreach (var file in provider.Contents)
    {
        fileNames.Add(file.Headers.ContentDisposition.FileName.Trim('\"'));
        var buffer = await file.ReadAsByteArrayAsync();
        //hash values, reject request if needed
    }
    return Ok();

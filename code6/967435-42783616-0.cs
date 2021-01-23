    var result = new HttpResponseMessage(HttpStatusCode.OK);
    result.Content = new PushStreamContent(async (outputStream, httpContext, transportContext) =>
    {
        using (var zipStream = new ZipOutputStream(outputStream))
        {
            var employeeStream = _xmlRepository.GetEmployeeStream(); // PseudoCode
            zipStream.PutNextEntry("content.xml");
            await employeeStream.CopyToAsync(zipStream);
            outputStream.Flush();
        }
    });
    
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "FromPC.zip" };
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    return result;

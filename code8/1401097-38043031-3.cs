    var content = new StreamContent(Request.InputStream);
        content.Headers.ContentType =
            System.Net.Http.Headers.MediaTypeHeaderValue.Parse(
                "multipart/form-data; 8f2a0a01-2114-42ca-a176-51badb488534");
        var streamProvider = content.ReadAsMultipartAsync().Result;
        foreach (var contentPart in streamProvider.Contents)
        {
            if (contentPart.Headers.ContentType.MediaType == "audio/wav")
            {
                var bytes = contentPart.ReadAsByteArrayAsync().Result;
            }
        }

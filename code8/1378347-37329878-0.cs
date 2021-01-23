    RawHttpHandlers.Add(_ => new CustomActionHandler((req, res) =>
    {
        var bytes = req.InputStream.ReadFully();
        var proxyUrl = settings.OtherServiceURL.CombineWith(req.RawUrl);
        var responseBytes = proxyUrl.SendBytesToUrl(method: req.Verb,
            requestBody: bytes,
            accept:MimeTypes.Json,
            contentType: req.ContentType, 
            responseFilter: webRes =>
            {
                res.StatusCode = (int)webRes.StatusCode;
                res.StatusDescription = webRes.StatusDescription;
                res.ContentType = webRes.ContentType;
            });
        res.OutputStream.Write(responseBytes, 0, responseBytes.Length);
    }));

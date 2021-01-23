    public HttpResponseMessage GetCervezaBeberUpdate(string clientVersion)
    {
        var binaryFilePath = HostingEnvironment.MapPath(@"~\App_Data\CervezaBeber.exe");
        FileVersionInfo currentVersion = FileVersionInfo.GetVersionInfo(binaryFilePath);
        if (!ServerFileIsNewer(clientVersion, currentVersion))
        {
            result = new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        else
        {
            var stream = new FileStream(binaryFilePath, FileMode.Open);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
        }
        return result;
    }

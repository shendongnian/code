    public HttpResponseMessage Download(string fileId, string extension)
    {
        var location = ConfigurationManager.AppSettings["FilesDownloadLocation"];
        var path = HttpContext.Current.Server.MapPath(location) + fileId + "." + extension;
    
        var result = new HttpResponseMessage(HttpStatusCode.OK);
        var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        return result;
    }

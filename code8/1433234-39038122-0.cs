    public async Task<bool> DownloadFile()
    {
        var uri = new Uri("http://somedomain.com/path");
        var request = WebRequest.CreateHttp(uri);
        var response = await request.GetResponseAsync();
        ContentDispositionHeaderValue contentDisposition;
        var fileName = ContentDispositionHeaderValue.TryParse(response.Headers["Content-Disposition"], out contentDisposition)
            ? contentDisposition.FileName
            : "noname.dat";
        using (var fs = new FileStream(@"C:\test\" + fileName, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            await response.GetResponseStream().CopyToAsync(fs);
        }
        return true
    }

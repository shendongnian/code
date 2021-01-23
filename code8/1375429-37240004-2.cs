    [System.Web.Http.HttpGet]
    public async Task<HttpResponseMessage> GetFile(string folder, string fileName) {
        using (var dbx = new DropboxClient("generated token")) {
            using (var file = await dbx.Files.DownloadAsync(folder + "/" + fileName)) {
                var content = await file.GetContentAsStringAsync();
                var statuscode = HttpStatusCode.OK;
                var response = Request.CreateResponse(statuscode);
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(content ?? ""));
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                    FileName = fileName
                };
                return response;
            }
        }
    }

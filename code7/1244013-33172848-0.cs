    public async Task<HttpStatusCode> UploadOrderFile(List<FileStream> imageFileStream, List<string> filename, string salesOrderNo, List<string> contentType)
        {
            JsonApiClient._client.DefaultRequestHeaders.Clear();
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
            var content = new MultipartFormDataContent(boundary); //todo boundary
            for (var i = 0; i < imageFileStream.Count; i++)
            {
                content.Add(JsonApiClient.CreateFileContent(imageFileStream[i], filename[i], contentType[i]));
            }
            JsonApiClient._client.DefaultRequestHeaders.Add("Authorization",
                " Bearer " + JsonApiClient.Token.AccessToken);
            var response = await JsonApiClient._client.PostAsync("api/UploadFile", content);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
    internal static StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
    {
        var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"files\"",
            FileName = "\"" + fileName + "\""
        }; 
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        return fileContent;
    }

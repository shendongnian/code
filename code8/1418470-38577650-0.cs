    [HttpPost]
    public async Task<HttpResponseMessage> Upload() {
        try {
            if (!Request.Content.IsMimeMultipartContent()) {
                Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            var provider = GetMultipartProvider();
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
            var originalFileName = GetDeserializedFileName(result.FileData.First());
            // uploadedFileInfo object will give you some additional stuff like file length,
            // creation time, directory name, a few filesystem methods etc..
            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);
            // Create full path for where to move the uploaded file
            string targetFile = Path.Combine(uploadedFileInfo.DirectoryName, originalFileName);
            // If the file in the full path exists, delete it first otherwise FileInfo.MoveTo() will throw exception
            if (File.Exists(targetFile)) 
                File.Delete(targetFile);
            }
            // Move the uploaded file to the target folder
            uploadedFileInfo.MoveTo(targetFile);
            // targetFile now contains the uploaded file
            // Through the request response you can return an object to the Angular controller
            // You will be able to access this in the .success callback through its data attribute
            // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
            return new HttpResponseMessage(HttpStatusCode.OK);
        } catch (Exception ex) {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new ObjectContent(ex.GetType(), ex, new JsonMediaTypeFormatter()) };
        }
    }
    private MultipartFormDataStreamProvider GetMultipartProvider() {
        var uploadFolder = @"C:\Temp"
            
        if (Directory.Exists(uploadFolder) == false) Directory.CreateDirectory(uploadFolder);
        return new MultipartFormDataStreamProvider(uploadFolder);
    }
    private string GetDeserializedFileName(MultipartFileData fileData) {
        var fileName = GetFileName(fileData);
        return JsonConvert.DeserializeObject(fileName).ToString();
    }
    private string GetFileName(MultipartFileData fileData) {
        return fileData.Headers.ContentDisposition.FileName;
    }

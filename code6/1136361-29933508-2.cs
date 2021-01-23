    private static StreamContent CreateFileContent(Stream fileStream, string fileName, string contentType)
    {
        //var stream = new FileStream(fileName, FileMode.Open);
        var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"files\"",
            FileName = "\"" + fileName + "\""
        }; // the extra quotes are key here
        
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        return fileContent;
    }

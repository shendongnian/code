    private Stream GetStreamFromDatabase(string fullFilePath)
    {
        //TODO
    }
    private static StreamContent FileMultiPartBody(string fullFilePath)
    {
        var fileContent = new StreamContent(GetStreamFromDatabase(fullFilePath))
        // Manually wrap the string values in escaped quotes.
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            FileName = string.Format("\"{0}\"", Path.GetFileName(fullFilePath)),
            Name = "\"signature\"",
        };
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        return fileContent;
    }

    [HttpGet]
    [DoNotChangeCacheSettings]
    public virtual FileResult DownloadTranslationFile(Guid id)
    {
        Guid assessmentTemplateId = id;
        File translationFile = Services.GetFileContent(assessmentTemplateId);
        var fileName = HttpUtility.UrlPathEncode(translationFile.FileName);
        var stream =  = new MemoryStream(translationFile.FileContent.Content);
        // Code for debugging
        var tempDir = "C:\\temp"; // Make sure app pool can write here.
        var path = Path.Combine(tempDir, fileName); // Possibly add extension here.
        using (var fileStream = File.Create(path))
        {
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
        }
        stream.Seek(0, SeekOrigin.Begin);
        // Return to client.
        return File(stream, "application/pdf", fileName);
    }

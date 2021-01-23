    [HttpGet]
    [DoNotChangeCacheSettings]
    public virtual FileResult DownloadTranslationFile(Guid id)
    {
        Guid assessmentTemplateId = id;
        File translationFile = Services.GetFileContent(assessmentTemplateId);
        var fileName = HttpUtility.UrlPathEncode(translationFile.FileName);
        var stream =  = new MemoryStream(translationFile.FileContent.Content);
        return File(stream, "application/pdf", fileName);
    }

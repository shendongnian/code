    [HttpGet]
    [DoNotChangeCacheSettings]
    public virtual FileResult DownloadTranslationFile(Guid id)
    {
        Guid assessmentTemplateId = id;
        File translationFile = Services.GetFileContent(assessmentTemplateId);
        var fileName = HttpUtility.UrlPathEncode(translationFile.FileName);
        return File(translationFile.FileContent.Content, "application/pdf", fileName);
    }

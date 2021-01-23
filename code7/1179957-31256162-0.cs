    public async Task<List<EntityUploadResult>> BulkUploadFiles(IEnumerable<BulkUploadFile> files)
    {
        var images = UploadImages(files.Where(x => x.FileType == BulkFileType.Image).AsEnumerable());
        var attachments = UploadAttachments(files.Where(x => x.FileType == BulkFileType.Attachment).AsEnumerable());
        var results = await Task.WhenAll(images, attachments);
        return results.SelectMany(_ => _).ToList();
    }

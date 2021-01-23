    FilesResource.UpdateMediaUpload r = service.Files.Update(f, fileId, stream, newMimeType);
    IUploadProgress progress =  r.Upload();
    if (progress.Status == UploadStatus.Failed)
    {
        if (progress.Exception != null)
        {
            throw progress.Exception;
        }
        else
        {
            throw new InvalidOperationException("upload process failed");
        }
    }

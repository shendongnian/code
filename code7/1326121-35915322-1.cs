    public UploadResponse Post(UploadRequest request)
    {
        Request.Files.ForEach(f => ProcessFile(f));
        return null;
    }
    private void ProcessFile(IHttpFile file)
    {
         // logic here
    }

    private readonly TimeSpan _delayDuration = TimeSpan.FromMinutes(20);
    
    public void Run(IBackgroundTaskInstance taskInstance)
    {
        taskInstance.GetDeferral();
        do
        {
            try
            {
                Monitor().Wait();
            }
            /* SNIP */
        }
        while (true);
    private async Task Monitor()
    {
        var webCam = await InitialiseWebCam();
        var image = await TakePicture(webCam);
        await UploadPictureToAzure(image);
        await Task.Delay(_delayDuration);
    }
 
    private async Task UploadPictureToAzure(StorageFile image)
        {
            var Azure_StorageAccountName = "accountname";
            var Azure_ContainerName = "container";
            var Azure_AccessKey = "key";
            try
            {
                StorageCredentials creds = new StorageCredentials(Azure_StorageAccountName, Azure_AccessKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, true);
                CloudBlobClient client = account.CreateCloudBlobClient();
                CloudBlobContainer sampleContainer = client.GetContainerReference(Azure_ContainerName);
            CloudBlockBlob blob = sampleContainer.GetBlockBlobReference(image.Name);
            await blob.UploadFromFileAsync(image);
        }
        catch (Exception ex)
        {
            /* Logging */
            throw ex;
        }
    }
    private async Task<MediaCapture> InitialiseWebCam()
    {
        var webCam = new MediaCapture();
        try
        {
            await webCam.InitializeAsync();
        }
        catch (Exception ex)
        {
           /* Logging */
           throw ex;
        }
        return webCam;
    }
    private async Task<StorageFile> TakePicture(MediaCapture webCam)
    {
        try
        {
            var image = await KnownFolders.PicturesLibrary.CreateFileAsync("Image.png", CreationCollisionOption.ReplaceExisting);
            var imageEncodingProperties = ImageEncodingProperties.CreatePng();
            await webCam.CapturePhotoToStorageFileAsync(imageEncodingProperties, image);
            return image;
        }
        catch (Exception ex)
        {
            /* Logging */
            throw ex;
        }
    }

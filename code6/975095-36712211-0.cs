    public ActionResult ShowPdf()
    {
        string fileName = "fileName.pdf";
    
        var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        var blobClient = storageAccount.CreateCloudBlobClient();
        var container = blobClient.GetContainerReference("containerName");
        var blockBlob = container.GetBlockBlobReference(fileName);
    
        Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
        return File(blockBlob.DownloadByteArray(), "application/pdf");
    }

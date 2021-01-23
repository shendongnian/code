    [HttpPost]
        public ActionResult GenerateSas(string optradio, string optcheck)
        {
    
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=;AccountKey=;";
    
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
    
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
            CloudBlobContainer container = blobClient.GetContainerReference("publiccontainer");
    
            var sasToken = container.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read
            });
    
            return View();
        }

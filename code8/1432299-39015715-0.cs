    public static CloudBlockBlob GetAzureBlob(string containername,string filename)
        {
            var creds = ConfigurationManager.AppSettings["azurestorageconn"];
            var azureStorage = CloudStorageAccount.Parse(creds);
            var client = azureStorage.CreateCloudBlobClient();
            //create a blob container and make it publicly accessibile
            var baseContainer = client.GetContainerReference(containername);  
            baseContainer.CreateIfNotExists();
            baseContainer.SetPermissions(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var blob = baseContainer.GetBlockBlobReference(filename);
            return blob;
        }

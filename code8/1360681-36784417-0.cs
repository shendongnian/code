            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var blobSharedAccessPolicy = new SharedAccessAccountPolicy()
            {
                Services = SharedAccessAccountServices.Blob,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
                Permissions = SharedAccessAccountPermissions.Write,
                ResourceTypes = SharedAccessAccountResourceTypes.Container
            };
            var sas = storageAccount.GetSharedAccessSignature(blobSharedAccessPolicy);
            var containerName = "created-using-account-sas";
            var containerUri = string.Format("{0}{1}", storageAccount.BlobEndpoint, containerName);
            var blobContainer = new CloudBlobContainer(new Uri(containerUri), new StorageCredentials(sas));
            blobContainer.Create();
            Console.WriteLine("Container created....");

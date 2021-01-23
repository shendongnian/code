            var account = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("container-name");
            var blob = container.GetBlockBlobReference("somefile.pdf");
            var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(15),
            }, new SharedAccessBlobHeaders()
            {
                ContentDisposition = "attachment; filename=\"somefile.pdf\"",
            });
            var downloadUrl = string.Format("{0}{1}", blob.Uri.AbsoluteUri, sasToken);//This URL will always do force download.

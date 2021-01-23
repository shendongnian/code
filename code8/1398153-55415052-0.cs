    public static Attachment MailAttachmentFromBlob(string docpath)
        {
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(storageContainer);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(docpath);
            blockBlob.FetchAttributes();
            long fileByteLength = blockBlob.Properties.Length;
            byte[] fileContent = new byte[fileByteLength];
            for (int i = 0; i < fileByteLength; i++)
            {
                fileContent[i] = 0x20;
            }
            blockBlob.DownloadToByteArray(fileContent, 0);
            return new Attachment{ Filename = "Attachmentname",
                Content = Convert.ToBase64String(fileContent),
                Type = "application/pdf",
                ContentId = "ContentId" };
           
        }

        bool IsBlobJpeg(string blobUri)
        {
            try
            {
                Microsoft.WindowsAzure.StorageClient.CloudBlob blob =
                    new CloudBlob(
                        blobUri);
                blob.FetchAttributes();
                return (blob.Properties.ContentType == "image/jpeg");
            }
            catch (StorageClientException ex)
            {
                Console.WriteLine(String.Format("{0} Does not exist", blobUri));
                return false;
            }
        }

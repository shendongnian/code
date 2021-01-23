    public List<string> ListBlob(string folder)
            {
                List<string> blobs = new List<string>();
    
                // Retrieve storage account from connection string.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("BlobConnectionString"));
    
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference(folder);
    
                // Loop over items within the container and output the length and URI.
                foreach (IListBlobItem item in container.ListBlobs(null, false))
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
    
                        blobs.Add(string.Format("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri));
    
                    }
                    else if (item.GetType() == typeof(CloudPageBlob))
                    {
                        CloudPageBlob pageBlob = (CloudPageBlob)item;
    
                        blobs.Add(string.Format("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri));
    
                    }
                    else if (item.GetType() == typeof(CloudBlobDirectory))
                    {
                        CloudBlobDirectory directory = (CloudBlobDirectory)item;
    
                        blobs.Add(string.Format("Directory: {0}", directory.Uri)); ;
                    }
                }
                return blobs;
            }
    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
            {           
                    BlobService list = new BlobService();
                    ListBox1.DataSource = list.ListBlob("mycontainer");
                    ListBox1.DataBind();
                       
            }

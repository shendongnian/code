    private CloudBlobContainer blobContainer;
    public void DeleteFile(string uniqueFileIdentifier)
    {
        this.AssertBlobContainer();
        var blob = this.blobContainer.GetBlockBlobReference(fileName);
        blob.DeleteIfExists();
    }
    private void AssertBlobContainer()
    {
    	// only do once
    	if (this.blobContainer == null)
    	{
    		lock (this.blobContainerLockObj)
    		{
    			if (this.blobContainer == null)
    			{
    				var client = this.cloudStorageAccount.CreateCloudBlobClient();
    
    				this.blobContainer = client.GetContainerReference(this.containerName.ToLowerInvariant());
    
    				if (!this.blobContainer.Exists())
    				{
    					throw new CustomRuntimeException("Container {0} does not exist in azure account", containerName);
    				}
    			}
    		}
    	}
    
    	if (this.blobContainer == null) throw new NullReferenceException("Blob Empty");
    }

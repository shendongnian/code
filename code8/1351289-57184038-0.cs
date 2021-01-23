    public async Task < bool > PerformTasks() {
    	try {
    		if (CloudStorageAccount.TryParse(StorageConnectionString, out CloudStorageAccount cloudStorageAccount)) {
    			var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
    			var cloudBlobContainer = cloudBlobClient.GetContainerReference(_blobContainerName);
    			if (await cloudBlobContainer.ExistsAsync()) {
    				BlobContinuationToken blobContinuationToken = null;
    				var blobList = await cloudBlobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
    				var cloudBlobList = blobList.Results.Select(blb = >blb as ICloudBlob);
    				foreach(var item in cloudBlobList) {
    					await item.DeleteIfExistsAsync();
    				}
                    return true;
    			}
    			else {
    				_logger.LogError(ErrorMessages.NoBlobContainerAvailable);
    			}
    		}
    		else {
    			_logger.LogError(ErrorMessages.NoStorageConnectionStringAvailable);
    		}
    	}
    	catch(Exception ex) {
    		_logger.LogError(ex.Message);
    	}
    	return false;
    }

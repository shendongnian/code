    // Loop over items within the container and output the length and URI.
    foreach (IListBlobItem item in container.ListBlobs(null, true))
    {
        if (item.GetType() == typeof(CloudBlockBlob))
        {
        	CloudBlockBlob blob = (CloudBlockBlob)item;
    			
    		if (blob != null)
    		{
    	    	blob.FetchAttributes();
                Console.WriteLine("Fetching Attributes");
    		 	string blobFilePath = blob.Uri.AbsolutePath.ToString();
    
    		 	if(String.compare(blobFilePath, filename, true) == 0) 
    		 	{
    		 		Console.WriteLine("Exists");
    		 	}
    		 	else
    		 	{
    		 		Console.WriteLine("Does Not Exist")
    		 	}
    
    	   		Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);
            }
        }
    }

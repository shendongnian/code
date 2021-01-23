    CloudBlobContainer blobContainer = blobClient.GetContainerReference("my-container");
    blobContainer.FetchAttributes();
    string count = blobContainer.Metadata["ItemCount"];
    int ItemCount;
    if(int.Tryparse(count ,out ItemCount))
    {
       if(ItemCount>0)
        // Container is not Empty
       else
        // Container is Empty  
    }
    else
    {
      // Conversion failed;
    }

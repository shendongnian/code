    //Code to get the last modified date
    CloudBlockBlob blockBlob = Container.GetBlockBlobReference(blobName);
    blockBlob.FetchAttributes();
    var lastModifiedDate = blockBlob.Properties.LastModified;
    Console.WriteLine(lastModifiedDate);  
              

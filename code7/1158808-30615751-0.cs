    // Get a reference to a blob.
    CloudBlob blob = blobClient.GetBlobReference("mycontainer/myblob.txt");
    // Populate the blob's attributes.
    blob.FetchAttributes();
    // Enumerate the blob's metadata.
    foreach (var metadataKey in blob.Metadata.Keys)
    {
    Console.WriteLine("Metadata name: " + metadataKey.ToString());
    Console.WriteLine("Metadata value: " +        
    blob.Metadata.Get(metadataKey.ToString()));
    }

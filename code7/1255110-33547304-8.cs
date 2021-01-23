    IAmazonS3 client;
    using (client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
    {
        // Build your request to list objects in the bucket
        ListObjectsRequest request = new ListObjectsRequest
        {
            BucketName = "MyBucketName"
        };
        do
        {
            // Build your call out to S3 and store the response
            ListObjectsResponse response = client.ListObjects(request);
            // Filter through the response to find keys that:
            // - end with the delimiter character '/' 
            // - are empty. 
            IEnumerable<S3Object> folders = response.S3Objects.Where(x =>
                x.Key.EndsWith(@"/") && x.Size == 0);
            // Do something with your output keys.  For this example, we write to the console.
            folders.ToList().ForEach(x => System.Console.WriteLine(x.Key));
            // If the response is truncated, we'll make another request 
            // and pull the next batch of keys
            if (response.IsTruncated)
            {
                request.Marker = response.NextMarker;
            }
            else
            {
                request = null;
            }
        } while (request != null);
    }

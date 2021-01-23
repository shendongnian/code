    IMongoDatabase database;
    
    var bucket = new GridFSBucket(database, new GridFSOptions
    {
        BucketName = "videos",
        ChunkSizeBytes = 1048576, // 1MB
        WriteConcern = WriteConcern.Majority,
        ReadPreference = ReadPeference.Secondary
    }); 
    
    IGridFSBucket bucket;
    bytes[] source;
    var options = new GridFSUploadOptions
    {
        ChunkSizeBytes = 64512, // 63KB
        Metadata = new BsonDocument
        {
            { "resolution", "1080P" },
            { "copyrighted", true }
        } 
    };  
     
    var id = bucket.UploadFromBytes("filename", source, options);
    

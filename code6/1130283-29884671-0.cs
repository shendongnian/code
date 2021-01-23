    var grid = new MongoGridFS(new MongoServer(new MongoServerSettings { Server = new MongoServerAddress(Settings.Default.WizdooMongoConnectionString) }), Settings.Default.WizdooMongoDatabaseName, new MongoGridFSSettings());
            grid.Upload(file.InputStream, file.FileName, new MongoGridFSCreateOptions
            {
                Id = imageId,
                ContentType = file.ContentType
            });
    //Yealds: The settings property 'ConnectionString' was not found.

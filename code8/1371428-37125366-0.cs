    public AppHost() : base("AWS Examples", typeof(AppHost).Assembly)
    {
    #if !DEBUG
        //Deployed RELEASE build uses Config settings in DynamoDb
        AppSettings = new MultiAppSettings(
            new DynamoDbAppSettings(newPocoDynamo(AwsConfig.CreateAmazonDynamoDb()),
                initSchema:true),
            new AppSettings());
    #endif
    }

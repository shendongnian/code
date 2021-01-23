    private static void InitializeCors()
    {
         // CORS should be enabled once at service startup
         // Given a BlobClient, download the current Service Properties 
         ServiceProperties blobServiceProperties = BlobClient.GetServiceProperties();
         ServiceProperties tableServiceProperties = TableClient.GetServiceProperties();
    
         // Enable and Configure CORS
         ConfigureCors(blobServiceProperties);
         ConfigureCors(tableServiceProperties);
                
         // Commit the CORS changes into the Service Properties
         BlobClient.SetServiceProperties(blobServiceProperties);
         TableClient.SetServiceProperties(tableServiceProperties);
    }
    
    private static void ConfigureCors(ServiceProperties serviceProperties)
    {
        serviceProperties.Cors = new CorsProperties();
        serviceProperties.Cors.CorsRules.Add(new CorsRule()
        {
            AllowedHeaders = new List<string>() { "*" },
            AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
            AllowedOrigins = new List<string>() { "*" },
            ExposedHeaders = new List<string>() { "*" },
            MaxAgeInSeconds = 1800 // 30 minutes
         });
    }

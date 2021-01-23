    foreach (string snsRegion in Configuration["SNSRegions"].Split(',', StringSplitOptions.RemoveEmptyEntries))
    {
        services.AddAWSService<IAmazonSimpleNotificationService>(
            string.IsNullOrEmpty(snsRegion) ? null :
            new AWSOptions()
            {
                Region = RegionEndpoint.GetBySystemName(snsRegion)
            }
        );
    }
    
    services.AddSingleton<ISNSFactory, SNSFactory>();
    
    services.Configure<SNSConfig>(Configuration);

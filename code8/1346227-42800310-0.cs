    string publicKey = File.ReadAllText("public.txt");
    string privateKey = File.ReadAllText("private.txt");
    
    using (var client = new AmazonSimpleNotificationServiceClient())
    {
        var request = new CreatePlatformApplicationRequest()
        {
            Name = Client,
            Platform = TargetPlatform,
            Attributes =
                    new Dictionary<string, string>()
                    {
                    {"PlatformCredential", privateKey },
                    {"PlatformPrincipal", publicKey }
                    }
        };
        var response = client.CreatePlatformApplication(request);
    }

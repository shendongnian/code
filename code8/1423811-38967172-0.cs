    private async void Push()
            {
                CognitoAWSCredentials cognitoProvider = new CognitoAWSCredentials(UserId,
                       IdentitypoolID,
                       UnAuthRoleARN,
                       AuthRoleARN,
                       Region);
    
                using (var sns = new AmazonSimpleNotificationServiceClient(credentials, RegionEndpoint.USEast1))
                {
                    var channelOperation = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
    
                    CreatePlatformEndpointRequest epReq = new CreatePlatformEndpointRequest();
                    epReq.PlatformApplicationArn = "PlatformApplicationARN";
                    epReq.Token = channelOperation.Uri.ToString();
    
                    CreatePlatformEndpointResponse epRes = await sns.CreatePlatformEndpointAsync(epReq);
    
                    CreateTopicRequest tpReq = new CreateTopicRequest();
    
                    SubscribeResponse subsResp = await sns.SubscribeAsync(new SubscribeRequest()
                    {
                        TopicArn = "TopicARN",
                        Protocol = "application",
                        Endpoint = epRes.EndpointArn
                    });
    
                    channelOperation.PushNotificationReceived += ChannelOperation_PushNotificationReceived;
                }
            }

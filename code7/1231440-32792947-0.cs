    var request = new PublishRequest()
    {
        TopicArn = TOPIC_ARN,
        Message = "{ \"default\": \"default message\", \"WNS\" : \"raw message\"}",
        MessageAttributes = new Dictionary<string, MessageAttributeValue>()
        {
            { "AWS.SNS.MOBILE.WNS.Type", new MessageAttributeValue() { StringValue = "wns/raw", DataType = "String" } }
        },
        MessageStructure = "json",
    };

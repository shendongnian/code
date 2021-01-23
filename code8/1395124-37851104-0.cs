    AmazonDynamoDBClient client = new AmazonDynamoDBClient();
    
    var request = new ScanRequest
    {
        TableName = "yourTableName",
        Limit = 10
    };
    
    var response = client.Scan(request);
    var result = response.ScanResult;
    
    foreach (Dictionary<string, AttributeValue> item in response.ScanResult.Items)
    {
      PrintItem(item);
    }

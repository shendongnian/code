    private void SendToKinesis(ITweet tweet)
    {
        var dataAsJson = JsonConvert.SerializeObject<ITweet>(tweet);
        byte[] dataAsBytes = Encoding.UTF8.GetBytes(dataAsJson);
       //Send to Kinesis
    }

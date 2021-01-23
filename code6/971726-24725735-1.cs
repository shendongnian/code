        PDAErsteinMobileServiceClient client = new PDAErsteinMobileServiceClient();
        using (OperationContextScope scope = new OperationContextScope(client.InnerChannel)) {
                    HttpRequestMessageProperty request = new HttpRequestMessageProperty();
                    request.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " + EncodeCredentials("foo", "foofoo");
                    OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, request);
                    client.GetAttelageCollectionAsync();
                    }
    
    //use this function 
    private string EncodeCredentials(string username, string password) {
        string credentials = username + ":" + password;
        var asciiCredentials = (from c in credentials
                                select c <= 0x7f ? (byte)c : (byte)'?').ToArray();
    
        return Convert.ToBase64String(asciiCredentials);
    }

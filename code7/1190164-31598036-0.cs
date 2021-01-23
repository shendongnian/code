    var cloudIdentity = new CloudIdentity
    {
        Username = "{username}",
        APIKey = "{api-key}"
    };
    var cloudIdentityProvider = new CloudIdentityProvider(cloudIdentity);
    var userAccess = cloudIdentityProvider.Authenticate(cloudIdentity);
    var request = new HttpRequestMessage(HttpMethod.Post, string.Format("https://identity.api.rackspacecloud.com/v2.0/users/{0}", userAccess.User.Id));
    request.Headers.Add("X-Auth-Token", userAccess.Token.Id);
    
    var requestBody = JObject.FromObject(new { user = new { username = userAccess.User.Name } });
    ((JObject)requestBody["user"]).Add("OS-KSADM:password", "{new-password}");
    request.Content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");
                
    using (var client = new HttpClient())
    {
        var response = client.SendAsync(request).Result;
    }

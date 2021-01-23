    var request = new HttpRequestMessage(HttpMethod.Post, "http://server.com/token");
    request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
        { OpenIdConnectParameterNames.ClientId, "your client_id" },
        { OpenIdConnectParameterNames.ClientSecret, "your client_secret" },
        { OpenIdConnectParameterNames.GrantType, "client_credentials" }
    });
    
    var response = await client.SendAsync(request, notification.Request.CallCancelled);
    response.EnsureSuccessStatusCode();
    
    var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
    var token = payload.Value<string>("access_token");

    var client = new RestClient { BaseUrl = Constants.API_BASE_URI };
    var request = new RestRequest("Token", HttpMethod.Post, ContentTypes.FormUrlEncoded);
    request.AddHeader("Accept", "application/json");
    request.AddParameter("grant_type", "password", ParameterEncoding.UriEncoded);
    request.AddParameter("username", userEntry.Text, ParameterEncoding.UriEncoded);
    request.AddParameter("password", passwordEntry.Text, ParameterEncoding.UriEncoded);
        
    var result = await client.SendAsync<AuthToken>(request);

     public RestClient getClient2(string user, string token)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(user, token);                
            //client.Authenticator = new OAuth2UriQueryParameterAuthenticator(token); //works
            //client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token); // doesn't work
    
            return client;
        }
    
      public GitHubUser GetGitHubUser2()
        {
            RestRequest request = new RestRequest();        
            request.Resource = "/users/huj";
            request.RootElement = "GitHubUser";
    
            RestClient client = getClient2(myUser, myToken);
    
            return Execute<GitHubUser>(client, request);        
        }
    
    
        /// <summary>
        /// http://stackoverflow.com/questions/30133937/how-to-use-oauth2-in-restsharp
        /// </summary>
        /// <returns>GitHubUser</returns>
        public GitHubUser GetGitHubUser3()
        {
            //RestRequest request = new RestRequest(Method.POST);  //empty data
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("grant_type", "client_credentials");
    
            request.Resource = "/users/huj";
            request.RootElement = "GitHubUser";
    
            RestClient client = getClient2(myUser, myToken);
    
            return Execute<GitHubUser>(client, request);
        }

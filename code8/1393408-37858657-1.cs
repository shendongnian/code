        // Serialize our concrete class into a JSON String
        var jsonInvitation = JsonConvert.SerializeObject(invitationObject);
        // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
        var stringContent = new StringContent(jsonInvitation);
        
        // Get the access token
        var token = GetAccessToken().AccessToken;
        
        // Create a Uri 
        var postUri = new Uri("https://invitations-api.trustpilot.com/v1/private/business-units/{BusinessUnitID}/invitations");
        // Set up the request
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, postUri);
        request.Content = stringContent;
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        request.Content.Headers.Add("token", token);
         // Set up the HttpClient
        var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Accept.Clear();
        //httpClient.BaseAddress = postUri;
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US"));
        var task = httpClient.SendAsync(request);
        
        task.Wait();

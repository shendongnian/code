    var client = new RestClient("http://example.com");
    // client.Authenticator = new HttpBasicAuthenticator(username, password);
    
    var request = new RestRequest("resource/{id}", Method.POST);
    request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
    request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

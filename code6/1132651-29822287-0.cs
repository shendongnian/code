    using RestSharp;
    var client = new RestClient("http://example.com");
    // client.Authenticator = new HttpBasicAuthenticator(username, password);
    var request = new RestRequest("resource/{id}", Method.POST);
    request.AddParameter("name", "value"); 
    request.AddUrlSegment("id", "123"); 
    // easily add HTTP Headers
    request.AddHeader("header", "value");
    // add files to upload (works with compatible verbs)
    request.AddFile(path);
    // execute the request
    RestResponse response = client.Execute(request);

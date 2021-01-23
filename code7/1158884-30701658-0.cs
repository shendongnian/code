    var client = new RestClient("http://www.myapp.com/Tracker.json");
    // client.Authenticator = new HttpBasicAuthenticator(username, password);
    var request = new RestRequest("", Method.POST);
    // execute the request
    RestResponse response = client.Execute(request);
    var content = response.Content; // raw content as string

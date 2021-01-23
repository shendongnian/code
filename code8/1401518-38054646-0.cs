    // URL
    string URL = "http://localhost:10189/portal/";
    // client URL                 
    var client = new RestClient(URL);
    // what you want to do
    var request = new RestRequest("adduser", Method.POST);
    //Login-Data - if necessary
    client.Authenticator = new HttpBasicAuthenticator("user", "password");
    // the response you are looking for
    IRestResponse response = client.Execute(request);
    // return it to you
    return response.Content;   

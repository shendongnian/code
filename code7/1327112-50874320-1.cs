    RestClient client = new RestClient(baseUrl);
    RestRequest request = new RestRequest(remainingPartOfURL, Method.POST);
    client.Authenticator = new HttpBasicAuthenticator(userId, password);
    request.AddHeader("Content-Type", "application/xml");
    request.AddHeader("Accept", "application/json");
    request.AddFile("myFile", "D:\\file.xml");
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    IRestResponse response = client.Execute(request);
    if (response != null)
                Console.WriteLine(response.Content); 

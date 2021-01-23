    // set up the REST Client
    string baseServiceUrl = "http://localhost:22343/SIGService.svc";
    RestClient client = new RestClient(baseServiceUrl);
    // define the request
    RestRequest request = new RestRequest();
    request.Method = Method.GET;
    request.RequestFormat = DataFormat.Xml;
    request.Resource = "GetTicket/{user}/{pwd}";
    request.AddParameter("user", "daniel", ParameterType.UrlSegment);
    request.AddParameter("pwd", "top$ecret", ParameterType.UrlSegment);
    // make the call and have it deserialize the XML result into a Ticket object
    var result = client.Execute<Ticket>(request);
    if (result.StatusCode == HttpStatusCode.OK)
    {
        Ticket ticket = result.Data;
    }

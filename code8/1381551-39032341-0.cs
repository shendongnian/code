    var client = Client(connection);   
    var request = new TestRequest(
        new Uri("http://website.net"),
        Locations.London,
        Browsers.Chrome);                          
    var response = client.SubmitTestAsync(request);
    if (response.Result.StatusCode == HttpStatusCode.OK && 
        response.Result.Body.State == ResultStates.Completed)
    {
        var pageLoadTime = response.Result.Body.Results.PageLoadTime;
        ...
    }

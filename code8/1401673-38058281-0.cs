    public IRestResponse UpdateOrder(string orderID, bool processing, DateTime procDate, bool Complete)
    {
        var request = new RestRequest(StreamUrl, Method.PUT)
        {
            RequestFormat = DataFormat.Json
        };
        request.AddParameter("OrderID", orderID);
        ...
        var response = _client.Execute<List<Stream>>(request);
        if (response.StatusCode == System.Net.HttpStatusCode.Created || response.StatusCode == System.Net.HttpStatusCode.OK)
            return response;
        else
            throw new Exception("Invalid input. Table could not be updated.");
    }

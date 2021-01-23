    public static string PostJson(string host, string resourceUrl, object json)
    {
        var client = new RestClient(host);
        client.Timeout = Settings.LIGHT_RESPONSE_TTL; //set timeout duration
        var request = new RestRequest(resourceUrl, Method.POST);
        request.RequestFormat = DataFormat.Json;
        request.AddBody(json);
        try
        {
            var response = client.Execute(request);
            return response.Content;
        }
        catch (Exception error)
        {
            Utils.Log(error.Message);
            return null;
        }
    }

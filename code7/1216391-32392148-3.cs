    protected static async Task<T> ExecuteRequestAsync<T>(string resource,
        HttpMethod method,
        object body = null,
        IEnumerable<Parameter> parameters = null) where T : new()
    {
        var client = new RestClient("http://example.com/rest/service.svc/");
        var req = new RestRequest(resource, method);
        AddRequestKeys(req);
        if (body != null)
            req.AddBody(body);
        if (parameters != null)
        {
            foreach (var p in parameters)
            {
                req.AddParameter(p);
            }
        }
        Func<Task<T>> result = async () =>
        {
            var response = await client.Execute<T>(req);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new Exception(response.Data.ToString());
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Error");
            return response.Data;
        };
        return await result();
    }

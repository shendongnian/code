    public T Deserialize<T>(RestSharp.IRestResponse response)
    {
        if (response.StatusCode == HttpStatusCode.Unauthorized) throw new System.UnauthorizedAccessException();
        if (response.StatusCode != HttpStatusCode.OK || !response.IsSuccessful) throw (new System.Exception(response.Content));
        var content = response.Content;
        return JsonConvert.DeserializeObject<T>(content);
    }

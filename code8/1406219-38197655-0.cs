    public async Task<string> callRestAPI(string serviceURL)
    {
        var getRequest = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, serviceURL);
        var postRequest = new System.Net.Http.HttpRequestMessage(HttpMethod.Post, serviceURL);
        postRequest.Content = new StringContent("string data");
        using (var httpClient = new System.Net.Http.HttpClient())
        {
            var getResponse = await httpClient.SendAsync(getRequest);
            var postResponse = await httpClient.SendAsync(postRequest);
            var getData = await getResponse.Content.ReadAsStringAsync();
            var postData = await postResponse.Content.ReadAsStringAsync();
            Debug.WriteLine(getData);
            Debug.WriteLine(postData);
            return getData;
        }
    }

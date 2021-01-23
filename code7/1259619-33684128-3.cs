    [HttpGet]
    public async Task<HttpResponseMessage> GetWidget(int id)
    {
        HttpClient client = new HttpClient();
        string url = "http://nextapiserver.example.org/widgets/" + id;
        string json = await client.GetStringAsync(url);
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");
        return response;
    }

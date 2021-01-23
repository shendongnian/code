    [HttpGet]
    public async Task<HttpResponseMessage> GetWidget(int id)
    {
        HttpClient client = new HttpClient();
        string url = "http://nextapiserver.example.org/widgets/" + id;
        string json = await client.GetStringAsync(url);
        return Request.CreateResponse(HttpStatusCode.OK, json);
    }

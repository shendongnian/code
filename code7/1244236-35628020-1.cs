    [HttpHead]
    [HttpGet]
    [ResponseType(typeof(string))]
    public HttpResponseMessage LiveCheck(HttpRequestMessage request)
    {
        HttpResponseMessage response;
     
        response =  request.CreateResponse(HttpStatusCode.OK);
        if (request.Method == HttpMethod.Get)
        {
            response.Content = new StringContent("OK", System.Text.Encoding.UTF8, "text/plain");
        }
        return response;
    }

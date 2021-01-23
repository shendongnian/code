    [System.Web.Http.HttpPost]
    public async Task<HttpResponseMessage> Save([FromBody]object data)
    {
        ...<snip>...
    
        return new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.Unauthorized,
            Content = new JsonContent(JObject.FromObject(new
            {
                success = false,
                message = "User not authorised to perform this action."
            }))
        };
    }

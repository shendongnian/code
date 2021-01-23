    public HttpResponseMessage GetAllServers()
    {
        if(ServerListHandler.Servers == null)
            return Request.CreateResponse(HttpStatusCode.NoContent);
        
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(ServerListHandler.Servers, Encoding.UTF8, "application/json");
        return response;
    }

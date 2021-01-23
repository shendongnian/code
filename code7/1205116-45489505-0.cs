    public async Task<IHttpActionResult> Get() 
    { 
        var response = Request.CreateResponse();
        response.Headers.Add("Lorem", "ipsum");
        return base.ResponseMessage(response); 
    }

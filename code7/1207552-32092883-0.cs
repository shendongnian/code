    public HttpResponseMessage Get()
    {
      
        return Request.CreateResponse(HttpStatusCode.OK, 
            new { Id = iUser.UserId, Name = iUser.UserName });
    }

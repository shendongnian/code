    public IHttpActionResult Get(int id)
    {
        if(id == 10)
        {
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    
        return Ok("Some value");
    }
